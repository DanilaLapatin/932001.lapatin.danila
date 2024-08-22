function create() {
    let fr = document.getElementById('content');
    let str = document.getElementsByClassName('table');
    let orig = str[str.length - 1]
    let el = orig.cloneNode(true);
    el.children[0].value=Number(orig.children[0].value)+1;
    fr.appendChild(el);
    
}

function del(el) {
    let fr = document.getElementById('content');
    let prnt = el.parentNode;
    fr.removeChild(prnt);
}

function up(el) {
    par = el.parentNode;
    let fr = document.getElementById('content');
    let sosed = par.previousSibling;
    fr.insertBefore(par, sosed);
}

function down(el) {
    par = el.parentNode;
    let fr = document.getElementById('content');
    let sosed = par.nextSibling;
    fr.insertBefore(par, sosed.nextSibling);
}

function save() {
    let el = document.createElement('div');
    el.classList.add("save");
    el.innerHTML = '{';
    document.body.appendChild(el);
    let object = document.getElementsByClassName('table');
    for (const key in object) {
        if (object.hasOwnProperty(key)) {
            if (object[key] != document.getElementsByClassName('table')[0]) {
                el.innerHTML += '"' + object[key].children[0].value + '":"' + object[key].children[1].value + '"';
                if (object[key].nextSibling != undefined) {
                    el.innerHTML += ',';
                }
            }
        }
    }
    el.innerHTML += '}';
}
