from flask import Flask, request, jsonify
import tensorflow as tf
import numpy as np
from tensorflow.keras.preprocessing import image
import io

app = Flask(__name__)

MODEL_PATH = 'model.keras'
model = tf.keras.models.load_model(MODEL_PATH)

target = 256

def prepare_image(img_bytes):
    img = image.load_img(io.BytesIO(img_bytes), target_size=(target, target))
    img_array = image.img_to_array(img).astype('float32')
    img_array = np.expand_dims(img_array, axis=0)
    return img_array

@app.route('/predict', methods=['POST'])
def predict():
    try:
        if 'image' not in request.files:
            return jsonify({'error': 'Görsel yüklenmedi.'}), 400

        file = request.files['image']
        img_bytes = file.read()
        img_input = prepare_image(img_bytes)

        pred = model.predict(img_input)[0][0]
        p0 = (1 - pred) * 100
        p1 = pred * 100
        label = 'Pozitif (glokom var)' if pred > 0.5 else 'Negatif (glokom yok)'

        return jsonify({
            'result': label,
            'probability_positive': round(float(p1), 2),
            'probability_negative': round(float(p0), 2)
        })

    except Exception as e:
        return jsonify({'error': f'İşleme sırasında hata oluştu: {str(e)}'}), 500

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5003)
