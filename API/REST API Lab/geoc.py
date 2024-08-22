import typing
from decimal import Decimal
import requests
from datetime import date
import pandas as pd
import geocoder

today = date.today()

WMO = {
    0:"Чистое небо",
    1:"В основном ясно",
    2:"Переменная облачность",
    3:"Пасмурно",
    45:"Туман",
    48:"Отложение инея",
    51:"Лёгкая морось",
    53:"Умеренная морось",
    55:"Интенсивная морось",
    56:"Лёгкий моросящий дождь",
    57:"Плотный моросящий дождь",
    61:"Слабый дождь",
    63:"Умеренный дождь",
    65:"Сильный дождь",
    66:"Слабый ледяной дождь",
    67:"Сильный ледяной дождь",
    71:"Слабый снегопад",
    73:"Умеренный снегопад",
    75:"Сильный снегопад",
    77:"Снежные зёрна",
    80:"Слабые ливни",
    81:"Умеренные ливни",
    82:"Сильные ливни",
    85:"Небольшой снегопад",
    86:"Сильный снегопад",
    95:"Гроза: слабая или умеренная",
    96:"Гроза с небольшим градом",
    99:"Гроза с сильным градом",
    }

YGBASE_URL='https://geocode-maps.yandex.ru/1.x'
OMBASE_URL="https://api.open-meteo.com/v1/forecast"

omparams = {
    "latitude":56.4977, 
    "longitude":84.9744,
    "daily":"weathercode,temperature_2m_max,rain_sum,snowfall_sum,windspeed_10m_max",
    "timezone":"Asia/Tomsk",
    "start_date":"2022-12-31",
    "end_date":"2023-09-20",
    }

ygparams = {
    "apikey":"2ac760d6-57e3-4f8d-8ea2-de0604590c90",
    "geocode":"Томск",
    "format":"json",
    }

omresponse=requests.get(OMBASE_URL,params=omparams)
ygresponse=requests.get(YGBASE_URL,params=ygparams)

if ygresponse.status_code==200:

    got: dict[str, typing.Any] = ygresponse.json()["response"]
    data=got["GeoObjectCollection"]["featureMember"]


    if not data:
        print(f'Nothing found for "Томск"')
        pass
   
    coordinates: str = data[0]["GeoObject"]["Point"]["pos"]
    longitude, latitude = tuple(coordinates.split(" "))

    my_file = open("BabyFile.txt", "w+")
    my_file.write(f"Координаты Томска: широта = "+str(latitude)+", долгота = "+str(longitude)+"\n")
elif ygresponse.status_code == 403:
    print('InvalidKey')
else:
    print(f"Ошибка: {ygresponse.status_code}: {ygresponse.text}")

if omresponse.status_code==200:
    data=omresponse.json()
    time = data['daily']['time']
    temp_2m_max = data['daily']['temperature_2m_max']
    weathercode = data['daily']['weathercode']
    rain_sum = data['daily']['rain_sum']
    snowfall_sum = data['daily']['snowfall_sum']
    windspeed_10m_max = data['daily']['windspeed_10m_max']
    start_date="2022-12-31"
    end_date="2023-09-20"
    my_file = open("BabyFile.txt", "a")
    my_file.write("Погода в Томске с "+start_date+" по "+end_date+"\n")
    for Time,Tmax,WeathCode,RainS,SnowS,WindSpeed in zip(time,temp_2m_max,weathercode,rain_sum,snowfall_sum,windspeed_10m_max):
        if Tmax == None and WeathCode == None and RainS == None and SnowS == None and WindSpeed== None:
            my_file.write("Дата: "+str(Time)+": Нет данных.\n")
            continue
        my_file.write("Дата: "+str(Time)+" ")
        my_file.write("Максимальная температура: "+str(Tmax)+", ")
        try:
            my_file.write("Описание: "+str(WMO[WeathCode])+", ")
        except:
            my_file.write("Описание: ..., ")
        if round(RainS,1)!=0.0:
            my_file.write("Дождь: "+str(RainS)+", ")
        if round(SnowS,1)!=0:
            my_file.write("Снег: "+str(SnowS)+", ")
        my_file.write("Скорость ветра: "+str(WindSpeed)+".\n")
    my_file.close()
else:
    print(f"Ошибка {omresponse.status_code}: {omresponse.text}")
