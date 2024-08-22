document.getElementById('br').onclick = function() {
    let number = Number(document.getElementById("number").value);
    for (let j = 0; j < number; j++) {
        let d = document.createElement('div');
        d.classList.add("rectangle");
        d.style.left = Math.floor(Math.random() * 1000) + 'px';
        d.style.top = Math.floor(Math.random() * 300 + 150) + 'px';
        let siz = Math.floor(Math.random() * 50 + 10);
        d.style.width = siz + 'px';
        d.style.height = siz + 'px';
        document.body.appendChild(d);
    }
}
document.getElementById('bt').onclick = function() {
    let number = Number(document.getElementById("number").value);
    for (let j = 0; j < number; j++) {
        let d = document.createElement('div');
        d.classList.add("triangle");
        d.style.left = Math.floor(Math.random() * 1000) + 'px';
        d.style.top = Math.floor(Math.random() * 300 + 150) + 'px';
        let siz = Math.floor(Math.random() * 100 + 50);
        d.style.borderLeft = siz + 'px solid transparent';
        d.style.borderRight = siz + 'px solid transparent';
        d.style.borderBottomWidth = siz + 'px solid blue';
        document.body.appendChild(d);
    }
}
document.getElementById('bc').onclick = function() {
    let number = Number(document.getElementById("number").value);
    for (let j = 0; j < number; j++) {
        let d = document.createElement('div');
        d.classList.add("circle");
        d.style.left = Math.floor(Math.random() * 1000) + 'px';
        d.style.top = Math.floor(Math.random() * 300 + 150) + 'px';
        let siz = Math.floor(Math.random() * 100 + 50);
        d.style.width = siz + 'px';
        d.style.height = siz + 'px';
        document.body.appendChild(d);
    }
}
function del(param){
    if(param.className=="rectangle"||param.className=="triangle"||param.className=="circle")
        param.remove();
}
document.addEventListener('dblclick',e => del(e.target));
