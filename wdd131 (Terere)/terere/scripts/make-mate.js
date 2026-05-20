const dropZone = document.getElementById('dropZone');
const congratsMessage = document.getElementById('congratsMessage');

const expectedOrder = ['copo', 'erva', 'suco', 'bomba'];
let currentOrder = [];

function resetDropZone() {
  currentOrder = [];
  dropZone.innerHTML = '<p>Drop the itens here</p>';
}

document.querySelectorAll('.item').forEach(item => {
  item.addEventListener('dragstart', function(ev) {
    ev.dataTransfer.setData('text/plain', ev.target.id);
  });
});

dropZone.addEventListener('dragover', function(ev) {
  ev.preventDefault();
  dropZone.classList.add('over');
});

dropZone.addEventListener('dragleave', function(ev) {
  dropZone.classList.remove('over');
});

dropZone.addEventListener('drop', function(ev) {
  ev.preventDefault();
  dropZone.classList.remove('over');
  
  const id = ev.dataTransfer.getData('text/plain');
  
  if (currentOrder.includes(id)) {
    alert('You already dropped this item!');
    return;
  }
  currentOrder.push(id);

  const img = document.createElement('img');
  img.src = document.getElementById(id).src;
  img.alt = id;
  img.classList.add('drop-item');
  dropZone.appendChild(img);

  if (currentOrder.length === expectedOrder.length) {
    if (arraysEqual(currentOrder, expectedOrder)) {
      congratsMessage.classList.remove('hidden');
    } else {
      alert('Wrong order, try again.');
      resetDropZone();
    }
  }
});


function arraysEqual(a, b) {
  return a.length === b.length && a.every((v, i) => v === b[i]);
}

//Mobile
document.querySelectorAll('.item').forEach(item => {
  item.addEventListener('touchstart', function(ev) {
    ev.preventDefault();
    const touch = ev.touches[0];
    ev.target.dataset.touchId = touch.identifier;
  });

  item.addEventListener('touchend', function(ev) {
    ev.preventDefault();
    const touch = ev.changedTouches[0];

    const dropRect = dropZone.getBoundingClientRect();
    if (
      touch.clientX >= dropRect.left &&
      touch.clientX <= dropRect.right &&
      touch.clientY >= dropRect.top &&
      touch.clientY <= dropRect.bottom
    ) {
      const id = ev.target.id;

      if (currentOrder.includes(id)) {
        alert('You already dropped this item!');
        return;
      }

      currentOrder.push(id);

      const img = document.createElement('img');
      img.src = ev.target.src;
      img.alt = id;
      img.classList.add('drop-item');
      dropZone.appendChild(img);

      if (currentOrder.length === expectedOrder.length) {
        if (arraysEqual(currentOrder, expectedOrder)) {
          congratsMessage.classList.remove('hidden');
        } else {
          alert('Wrong order, try again.');
          resetDropZone();
        }
      }
    }
  });
});
