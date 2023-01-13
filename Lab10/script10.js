function sliden() {
    document.getElementById('curtain').id = 'curtainup';
}

function on() {
    if (document.getElementById('light_off'))
    {
		document.getElementById('light_off').id = 'light_on';
		document.getElementById('fairy').style.display = 'block';
		document.getElementById('focus').style.display = 'block';
    }
	else
	{
		document.getElementById('light_on').id = 'light_off';
		document.getElementById('fairy').style.display = 'none';
		document.getElementById('focus').style.display = 'none';
	}
}

function focusing() {
    document.getElementById('rabbit_hidden').id = 'rabbit_show';
    document.getElementById('pigeon_show').id = 'pigeon_hidden';
}

function pigeon() {
    document.getElementById('rabbit_show').id = 'rabbit_hidden';
    document.getElementById('pigeon_hidden').id = "pigeon_show";
}