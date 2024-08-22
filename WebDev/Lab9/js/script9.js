function calculate() {
    let val = document.getElementById('inout').innerHTML;
    document.getElementById('inout').innerHTML = String(eval(val));
}

function clean() {
    document.getElementById('inout').innerHTML = "";
}

function delone() {
    let val = document.getElementById('inout').innerHTML;
    document.getElementById('inout').innerHTML = val.substring(0, val.length - 1);
}

function val(val) {
	let lastsym = document.getElementById('inout').innerHTML.slice(-1);
	let oper = ['+','-','*','/','.',''];
	if(oper.indexOf(val)!=-1 && oper.indexOf(lastsym)!=-1){      
		return
	}
	else document.getElementById('inout').innerHTML+= val;
}
