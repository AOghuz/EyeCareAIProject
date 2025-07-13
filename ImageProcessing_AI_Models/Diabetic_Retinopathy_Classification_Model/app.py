from flask import Flask, request, jsonify
import torch
from PIL import Image
import io
from torchvision import transforms

app = Flask(__name__)

# Sınıf isimleri – eğitim sırasında kullandığınız sıraya göre ayarlayın
class_names = ['Mild', 'Moderate', 'NO_DR', 'Proliferate_DR', 'Severe']

# Cihaz ayarı: GPU varsa kullanın, yoksa CPU
device = torch.device("cuda:0" if torch.cuda.is_available() else "cpu")

# TorchScript modelinizi yükleyin
model = torch.jit.load("efficientnetb5_finetuned_scripted.pt", map_location=device)
model.to(device)
model.eval()

# Ön işleme dönüşümleri: eğitim sırasında kullandığınız test dönüşümleriyle aynı olmalı.
test_transforms = transforms.Compose([
    transforms.Resize(256),
    transforms.CenterCrop(224),
    transforms.ToTensor(),
    transforms.Normalize(mean=[0.485, 0.456, 0.406],
                         std=[0.229, 0.224, 0.225])
])

def preprocess_image(image_bytes):
    """
    Gelen resim baytlarını PIL görüntüsüne çevirir,
    gerekli dönüşümleri uygular ve modelin beklediği (1, C, H, W) tensor formatına getirir.
    """
    image = Image.open(io.BytesIO(image_bytes)).convert("RGB")
    return test_transforms(image).unsqueeze(0)

@app.route('/predict', methods=['POST'])
def predict():
    # İstek içinde "file" bulunmazsa hata döndür.
    if 'file' not in request.files:
        return jsonify({"error": "No file provided"}), 400
    
    file = request.files['file']
    image_bytes = file.read()
    input_tensor = preprocess_image(image_bytes).to(device)
    
    with torch.no_grad():
        outputs = model(input_tensor)
        probabilities = torch.softmax(outputs, dim=1)[0]
        predicted_idx = probabilities.argmax().item()
    
    result = {
        "predicted_class": class_names[predicted_idx],
        "class_percentages": {class_names[i]: float(probabilities[i]) * 100 for i in range(len(class_names))}
    }
    return jsonify(result)

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)
