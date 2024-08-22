function chpok(id) {
    elem = document.getElementById(id)
    state = elem.style.display
    if (state == 'none') {
        document.getElementById('newsborder').style.opacity = '0.4'
        elem.style.display = 'block'
        document.getElementById('modnewsbg').style.display = 'block' //если elem.style.display == 'none', то показать блок с указанным id и фон на переднем плане для возврата назад
    } else {
        document.getElementById('modnewsbg').style.display = 'none'
        document.getElementById('newstext1').style.display = 'none'
        document.getElementById('newstext2').style.display = 'none'
        document.getElementById('newstext3').style.display = 'none'
        document.getElementById('newsborder').style.opacity = '1';// иначе вернуть всё как было сначала
    }
}
