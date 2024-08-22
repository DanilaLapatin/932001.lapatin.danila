import os
from bs4 import BeautifulSoup
from flask import render_template, request, redirect, url_for, send_from_directory,flash
from werkzeug.utils import secure_filename
from WebProject import app
from WebProject.Geocoder import Geocoder
import matplotlib.pyplot as plt

UPLOAD_FOLDER = os.path.dirname(os.path.abspath(__file__))+'/uploads/'
DOWNLOAD_FOLDER = os.path.dirname(os.path.abspath(__file__))+'/downloads/'
ALLOWED_EXTENSIONS = {'csv', 'xlsx'}


@app.route('/')
@app.route('/home')
def home():
    """Renders the home page."""
    return render_template('index.html')


@app.route('/uploading', methods=['GET', 'POST'])
def uploading():
    
    colnames=["Сумма","Время в пути", "День недели"]#имена колонок дополнительных характеристик

    VisTypes=["Маркеры","Тепловая карта"]

    return render_template(
        'uploading.html',
        colnames=colnames,
        VisTypes=VisTypes

        )


@app.route('/success/', methods = ['POST','GET']) 
def success():
    option=request.form['workcol']
    VisType=request.form['VisType']
    try:
        downfilter = float(request.form['lowedge'])
    except:
        downfilter=0.0
    try:
        upfilter = float(request.form['highedge'])
    except:
        upfilter = 1.7976931348623157e+308

    if request.method == 'POST':
        # проверим, передается ли в запросе файл 
        if 'file' not in request.files:

            return redirect(url_for('uploading'))

        file = request.files['file']

        if file.filename == '':
            return redirect(url_for('uploading'))

        if file and allowed_file(file.filename):
            delete_everything(app.config['UPLOAD_FOLDER'])

            f = request.files['file'] 
            f.save(os.path.join(app.config['UPLOAD_FOLDER'],f.filename))
            
            flash('Начало загрузки...')
            GC=Geocoder()
            

            mapName=os.path.splitext(f.filename)[0]+"-Карта "+option+" "+VisType+"Фильтры: "+str(downfilter)+","+str(upfilter)+".html"
            
            GC.TomGeocoder(os.path.join(app.config['UPLOAD_FOLDER'],f.filename),option,VisType,downfilter,upfilter)
            delete_everything(app.config['DOWNLOAD_FOLDER'])
            GC.SaveMap(app.config['DOWNLOAD_FOLDER'],'temp')

            delete_flag_from_map(os.path.join(app.config['DOWNLOAD_FOLDER'],'temp'),mapName)
            return send_from_directory(app.config["DOWNLOAD_FOLDER"], mapName, as_attachment=True)


def delete_flag_from_map(path,mapName):
    with open(path) as inf:
        txt = inf.read()
    soup = BeautifulSoup(txt,'html.parser')
    whiteblock = soup.new_tag("div")
    whiteblock["style"] = """
    position: fixed;
    z-index: 9999; 
    bottom: 0; 
    right: 0; 
    height: 3%; 
    width: 260px; 
    background-color: white; 
    text-align: center"""
    whiteblock.string = "Worked by WEBGEOPRO"
    soup.html.body.append(whiteblock)
    with open(os.path.join(app.config['DOWNLOAD_FOLDER'],mapName),'w') as f:
        f.write(str(soup))

def delete_everything(path):
    if os.listdir(path):
        for filename in os.listdir(path):
            file_path = os.path.join(path, filename)
            try:
                if os.path.isfile(file_path):
                    os.remove(file_path)
            except Exception as e:
                print(f'Ошибка при удалении файла {file_path}. {e}')



def allowed_file(filename):
    """ Функция проверки расширения файла """
    return '.' in filename and \
           filename.rsplit('.', 1)[1].lower() in ALLOWED_EXTENSIONS
