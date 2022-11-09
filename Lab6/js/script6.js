
function funlr(id1,id2, id3) {
    if (document.getElementById(id1).style.display != 'none') {
        document.getElementById(id1).style.display = 'none'
        document.getElementById(id2).style.width = '2%'
        document.getElementById(id3).style.width = '98%'
    }
    else funcenter();
        
    }
    function funcenter(){
        document.getElementById('cat').style.display = 'block'
        document.getElementById('dog').style.display = 'block'
        document.getElementById('rightdiv').style.width = '50%'
        document.getElementById('leftdiv').style.width = '50%'
    }
