async function CargarComentarios() {
  const enlace = await fetch('/api/comentarios');
  const resultado = await enlace.json();

  const lista = document.getElementById('comentarioLista');
  lista.innerHTML = '';

  resultado.forEach(dato => {
    const li = document.createElement('li');
    li.className = 'collection-item';
    li.textContent = `${dato.nombre}: ${dato.mensaje}`;
    lista.appendChild(li);
  });
}

async function AgregarComentario() {
  const nombre = document.getElementById('nombre').value;
  const mensaje = document.getElementById('mensaje').value;

  if (!nombre || !mensaje){
    alert("Debe digitar la informacion requerida en los campos de nombre y comentario.")
    return
  };

  await fetch('/api/comentarios', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ nombre, mensaje })
  });

  document.getElementById('nombre').value = '';
  document.getElementById('mensaje').value = '';

  //Refresca los valores mediante la libreria de materialize.
  M.updateTextFields();

  CargarComentarios();
}

//Agrega efecto de zoom a las imagenes de la galeria.
document.addEventListener('DOMContentLoaded', () => {
  const elems = document.querySelectorAll('.materialboxed');
  M.Materialbox.init(elems);
});

//Carga los comentarios guardados en la pagina
CargarComentarios();
