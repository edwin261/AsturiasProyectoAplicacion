const express = require('express');
const app = express();
const PORT = 3000;

// Variable para almacenar temporalmente los comentarios generados por el usuario en el formulario de la pagina.
let comentarios = [];

app.use(express.json());
app.use(express.static('Public'));

// Obtener comentarios.
app.get('/api/comentarios', (req, res) => {
  res.json(comentarios);
});

// Agregar comentarios.
app.post('/api/comentarios', (req, res) => {
  const { nombre, mensaje } = req.body;

  if (!nombre || !mensaje) {
    return res.status(400).json({ error: 'No se agrego la informacion necesaria para crear un comentario.' });
  }

  comentarios.push({ nombre, mensaje });
  res.status(201).json(comentarios);
});

// Log informativo interno, inicio del servicio.
app.listen(PORT, () => {
  console.log(`Servidor iniciado en la ruta: http://localhost:${PORT}`);
});