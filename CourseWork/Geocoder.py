#from email import generator
#from msilib.schema import Icon
import os
import re
#import string
import folium
from folium.plugins import BeautifyIcon, HeatMap
import pandas as pd
#import openpyxl
from yandex_geocoder import Client
import geocoder

import branca.colormap as cm

pd.options.mode.chained_assignment = None

DOWNLOAD_FOLDER = os.path.dirname(os.path.abspath(__file__))+'/downloads/'




class Geocoder(object):

    client=Client("2ac760d6-57e3-4f8d-8ea2-de0604590c90")#API-ключ для Яндекс геокодера

    Worklist=[[],[],[]] #Worklist[0]-адреса, Worklist[1]-необходимые характеристики, Worklist[2]-координатьы

    colormap: cm.LinearColormap
    
    gcmap: folium.Map

    


    def __init__(self):
        return

    def TextRedactor(self,location,colname):

        self.Worklist=[[],[],[]]
        file_extension=os.path.splitext(location)[1]    

        if file_extension=='.xlsx':
            doc = pd.read_excel(location, parse_dates=['От','До','Создан'])        
        elif file_extension=='.csv':
            doc = pd.read_csv(location, on_bad_lines='skip',sep=';', parse_dates=['От','До','Создан'])

        addrlist = doc['Клиент / Адрес']
        if colname == 'От':
            workcolumn = pd.to_datetime(doc[colname], dayfirst=True, format = 'ISO8601')
        else:
            workcolumn = doc[colname]
        print(type(workcolumn[0]),workcolumn[0])
        if colname != 'От':
            if file_extension == '.csv':
                print(file_extension)
                #for  i in range(len(workcolumn)):
                #    val=workcolumn[i].replace(r"\xa0", "").replace(' ','').replace(',','.')
                #    workcolumn[i]=val
                    
        
        for address, val in zip(addrlist,workcolumn):
            text= str(address)
            if colname != 'От':
                try:
                    value = float(val)
                except:
                    value=0
            else:
                print(val)
                try:
                    value = val.weekday()
                    print(value)
                except:
                    print("Can't proccess this value")
                    value = 0   
            
            if len(text.split())<4 or len(text.split(','))<4:
                continue   
            if text.find('Россия')==-1:
                continue  
            textm=text[text.find('Россия'):].split(',')
            
            
            textm[-1].replace(os.sep, "/")
            try:
                helper = textm[2].split()
                helper = ''.join(helper)
                helper.replace(' ', '')
            except:
                helper = ":("
                textm=["ОШИБКА","В","ЭТОЙ","СТРОКЕ!!!!!!"]
            if helper.isdigit():
                textm[4].replace('дом','')
                hs=re.sub(r"\\", "/", textm[4])
                textm[4]=hs

                textm[3]=re.sub(r'\(.+?\)\s', '', textm[3])

                text=textm[0]+textm[1]+","+textm[2]+","+textm[3]+","+textm[4]
            else:
                textm[3].replace('дом','')
                hs=re.sub(r"\\", "/", textm[3])
                textm[3]=hs

                textm[2]=re.sub(r'\(.+?\)\s', '', textm[2])

                text=textm[0]+","+textm[1]+","+textm[2]+","+textm[3]
            if text not in self.Worklist[0]:
                self.Worklist[0].append(text)
                self.Worklist[1].append(value)
        return


    def ForwardGeocode(self, text):
        
            coordinates=geocoder.osm(text).latlng
            if coordinates==None:
                print("Can't geocode with Nominatim, we try with Yandex")
                try:
                    c=self.client.coordinates(text)
                    coordinates=[c[1],c[0]]
                except:
                    print("Can't geocode")
                    coordinates=[0,0]
            print(coordinates)
            return coordinates
                    

    def PointsColer(self):
        minimum=min(self.Worklist[1])
        maximum=max(self.Worklist[1])
        middle=(minimum+maximum)/2
        self.colormap= cm.LinearColormap(colors=['green','yellow','orange','red'],
                                         vmin=minimum, vmax=maximum)
        
  
    
    def TomGeocoder(self,location,colname,VisType,downfilter,upfilter):
        wcolname = colname
        if colname =="День недели":
            wcolname = 'От'
        
        self.TextRedactor(location,wcolname) 
        weekdays = ["понедельник", "вторник", "среда", "четверг", "пятница","суббота", "воскресенье"]
        
        #Начальные координаты и создание объекта карты
        try:
            startcoordinates=self.ForwardGeocode(self.Worklist[0][0])
            self.gcmap=folium.Map(location = startcoordinates, zoom_start = 12, minZoom = 4)
        except:
            print("Can't create map with Nominatim")

        addrnumber=0
        errorcount=0

        if VisType=="Тепловая карта":
            
            for text in self.Worklist[0]:
                try:
                    coordinates=self.ForwardGeocode(text)
                    self.Worklist[2].append(coordinates)
                    addrnumber=addrnumber+1
                except:
                    errorcount=errorcount+1
                    print("Can't geocode: ",addrnumber, text)
                    continue
            HeatMap(self.Worklist[2]).add_to(self.gcmap)
        else:
            self.PointsColer()

            main_group = folium.FeatureGroup(name='Все точки')
            
            filtername='От '+str(downfilter)+' до '+str(upfilter)
            filter_group = folium.FeatureGroup(name=filtername)
            nonfiltername='Меньше '+str(downfilter)+' или больше '+str(upfilter)
            nonfilter_group=folium.FeatureGroup(name=nonfiltername)
            

            print(filtername)

            for text,value in zip(self.Worklist[0],self.Worklist[1]): 
                
                col=self.colormap(value)
                
                try:
                    
                    coordinates=self.ForwardGeocode(text)
                    addrnumber=addrnumber+1
                    self.Worklist[2].append(coordinates)

                    if wcolname != 'От':
                        s = "Адрес: "+ text+", "+colname+": "+str(value)
                    else:
                        s = "Адрес: "+ text+", "+colname+": "+weekdays[value]
                    folium.Marker([coordinates[0],coordinates[1]], popup=s,icon=folium.plugins.BeautifyIcon(icon_shape='circle-dot',border_color=col,border_width=6)).add_to(main_group)

                    if value>=downfilter and value<=upfilter:
                        folium.Marker([coordinates[0],coordinates[1]], popup=s,icon=folium.plugins.BeautifyIcon(icon_shape='circle-dot',border_color=col,border_width=6)).add_to(filter_group)
                    else:
                        folium.Marker([coordinates[0],coordinates[1]], popup=s,icon=folium.plugins.BeautifyIcon(icon_shape='circle-dot',border_color=col,border_width=6)).add_to(nonfilter_group)
                       

                except:
                    errorcount=errorcount+1
                    print("Can't geocode: ",addrnumber, text, value,col)
                    continue
        
                print(s)
            
            self.colormap.add_to(self.gcmap)
            main_group.add_to(self.gcmap)
            filter_group.add_to(self.gcmap)
            nonfilter_group.add_to(self.gcmap)
            folium.LayerControl(position="bottomright").add_to(self.gcmap)

        print("Закодировано "+str(addrnumber)+" адресов. Количество ошибок при геокодировании: "+str(errorcount))
            

    def SaveMap(self,location,name):
        self.gcmap.save(os.path.join(location,name))



        

