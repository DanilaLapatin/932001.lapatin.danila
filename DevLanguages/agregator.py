import requests
from bs4 import BeautifulSoup
import queue
import threading
import time
#Класс-агрегатор новостей с сайтов
#'https://habr.com/ru/all'
#'https://tproger.ru/news'
#'https://stackoverflow.blog/'
#'https://ichip.ru/novosti'
#Принцип работы объяснён на примере методов HabrAgregate() и HabrAgrNew()

class Agregator:

   #Собрать все уже имеющиеся новости 
    def HabrAgregate(self,q):
        URL = 'https://habr.com/ru/all'
        response=requests.get(URL).text#Парсим всю страницу

        data = BeautifulSoup(response, 'html.parser')
        for articleSnippet in data.find_all('div', class_ = "tm-article-snippet tm-article-snippet"):
            article = articleSnippet.find('h2', class_ = "tm-title tm-title_h2")
            title = article.a.span.text
            annotation ='no annotation' #articleSnippet.find('div', {'class': None}).find('p').text почему-то не находит, при print(articleSnippet) не выводит необходимыедля парсинга аннотации классы
            link = 'https://habr.com' + article.a['href']# Ссылка на статью
            authorInfo = articleSnippet.find('a', class_ = "tm-user-info__username")
            author = authorInfo.text#Имя автора
            authorLink = 'https://habr.com'+ authorInfo['href']#Ссылка на автора
            infolist = []
            #Добавляем полученные строки в список
            infolist.append(title)
            infolist.append(annotation)
            infolist.append(link)
            infolist.append(author)
            infolist.append(authorLink)
            #Добавляем в очередь созданный список
            q.put(infolist)
    
    #Собрать все уже имеющиеся новости        
    def TprogerAgregate(self,q):
        URL = 'https://tproger.ru/news'
        response=requests.get(URL).text

        data = BeautifulSoup(response, 'html.parser')

        for articleSnippet in data.find_all('article', class_ = "tp-post-card"):
            article = articleSnippet.find('h2', class_ = "tp-post-card__title")
            title = article.a.text
            annotationInfo = articleSnippet.find('p', class_ = 'tp-post-card__text')
            annotation=annotationInfo.text
            link = 'https://tproger.ru' + article.a["href"]
            authorInfo = articleSnippet.find('a', class_ = "tp-post-card__author")
            author = authorInfo.text
            authorLink = 'https://tproger.ru'+ authorInfo["href"]
            infolist = []

            infolist.append(title)
            infolist.append(annotation)
            infolist.append(link)
            infolist.append(author)
            infolist.append(authorLink)

            q.put(infolist)
    
    #Собрать все уже имеющиеся новости       
    def SOFAgregate(self,q):
        URL = 'https://stackoverflow.blog/'
        response=requests.get(URL).text

        data = BeautifulSoup(response, 'html.parser')

        for articleSnippet in data.find_all('div', class_ = "flex--item6 d-flex fd-column"):
            article = articleSnippet.find('a', class_ = "fc-black h:fc-blue-400")
            title = article.h1.text
            annotationInfo = articleSnippet.find('p', class_ = 'fc-black-500 fs-body2 mb0 mt16')
            annotation=annotationInfo.text
            link = URL + article["href"]
            authorInfo = articleSnippet.find('div', class_ = "d-flex ai-center mt16")
            author = authorInfo.find('span', class_ ="fw-bold fs-body2").text
            authorLink = 'no link'
            infolist = []

            infolist.append(title)
            infolist.append(annotation)
            infolist.append(link)
            infolist.append(author)
            infolist.append(authorLink)

            q.put(infolist)
    
    #Собрать все уже имеющиеся новости
    def IchipAgregate(self,q):
        URL = 'https://ichip.ru/novosti'
        response=requests.get(URL).text

        pagedata = BeautifulSoup(response, 'html.parser')
        data= pagedata.find('main', class_ = "page-content")

        for articleSnippet in data.find_all('div', class_ = "details_item"):
            article = articleSnippet.find('div', class_ = "title")
            title = article.a["title"]
            annotation = articleSnippet.find('p', class_ = 'description').text
            link = URL + article.a["href"]
            author = "no author"
            authorLink = 'no link'
            infolist = []

            infolist.append(title)
            infolist.append(annotation)
            infolist.append(link)
            infolist.append(author)
            infolist.append(authorLink)

            q.put(infolist)
    
    #Искать новые новости
    def HabrAgrNew(self,q,allinfo):
        URL = 'https://habr.com/ru/all'
        response=requests.get(URL).text

        data = BeautifulSoup(response, 'html.parser')

        articleSnippet = data.find('div', class_ = "tm-article-snippet tm-article-snippet")
        article = articleSnippet.find('h2', class_ = "tm-title tm-title_h2")
        title = article.a.span.text
        annotation='no annotation'#articleSnippet.find('div', class_ = 'article-formatted-body article-formatted-body article-formatted-body_version-2').p.text
        link = 'https://habr.com' + article.a["href"]
        authorInfo = articleSnippet.find('a', class_ = "tm-user-info__username")
        author = authorInfo.text
        authorLink = 'https://habr.com'+ authorInfo["href"]
        artnumber=len(allinfo)
        #Проверка, есть ли среди СПИСКА новостей, которые уже выведены на экран, новость с таким заголовком
        for i in range(artnumber):
            if allinfo[i][0]==title:
                return
        
        infolist = []

        infolist.append(title)
        infolist.append(annotation)
        infolist.append(link)
        infolist.append(author)
        infolist.append(authorLink)
        
        return infolist

    #Искать новые новости
    def TprogerAgrNew(self,q,allinfo):
        URL = 'https://tproger.ru/news'
        response=requests.get(URL).text

        data = BeautifulSoup(response, 'html.parser')

        articleSnippet = data.find('article', class_ = "tp-post-card")
        article = articleSnippet.find('h2', class_ = "tp-post-card__title")
        title = article.a.text
        annotationInfo = articleSnippet.find('p', class_ = 'tp-post-card__text')
        annotation=annotationInfo.text
        link = 'https://tproger.ru' + article.a["href"]
        authorInfo = articleSnippet.find('a', class_ = "tp-post-card__author")
        author = authorInfo.text
        authorLink = 'https://tproger.ru'+ authorInfo["href"]

        for i in range(artnumber):
            if allinfo[i][0]==title:
                return
        
        infolist = []

        infolist.append(title)
        infolist.append(annotation)
        infolist.append(link)
        infolist.append(author)
        infolist.append(authorLink)
        
        return infolist

    #Искать новые новости
    def SOFAgrNew(self,q,allinfo):
        URL = 'https://stackoverflow.blog/'
        response=requests.get(URL).text

        data = BeautifulSoup(response, 'html.parser')

        articleSnippet = data.find('div', class_ = "flex--item6 d-flex fd-column")
        article = articleSnippet.find('a', class_ = "fc-black h:fc-blue-400")
        title = article.h1.text
        annotationInfo = articleSnippet.find('p', class_ = 'fc-black-500 fs-body2 mb0 mt16')
        annotation=annotationInfo.text
        link = URL + article["href"]
        authorInfo = articleSnippet.find('div', class_ = "d-flex ai-center mt16")
        author = authorInfo.find('span', class_ ="fw-bold fs-body2").text
        authorLink = 'no link'

        for i in range(artnumber):
            if allinfo[i][0]==title:
                return
        
        infolist = []

        infolist.append(title)
        infolist.append(annotation)
        infolist.append(link)
        infolist.append(author)
        infolist.append(authorLink)
        
        return infolist

    #Искать новые новости
    def IchipAgrNew(self,q,allinfo):
        URL = 'https://ichip.ru/novosti'
        response=requests.get(URL).text

        pagedata = BeautifulSoup(response, 'html.parser')
        data= pagedata.find('main', class_ = "page-content")

        articleSnippet = data.find('div', class_ = "details_item")
        article = articleSnippet.find('div', class_ = "title")
        title = article.a["title"]
        annotation = articleSnippet.find('p', class_ = 'description').text
        link = URL + article.a["href"]
        author = "no author"
        authorLink = 'no link'

        for i in range(artnumber):
            if allinfo[i][0]==title:
                return
        
        infolist = []

        infolist.append(title)
        infolist.append(annotation)
        infolist.append(link)
        infolist.append(author)
        infolist.append(authorLink)
        
        return infolist

    #Функция обёртка, поочерёдно запускает поиск новых новостей на сайтах и передаёт их в очередь, если находит
    def AgregateNewAll(self,q,allinfo):
        while True:
            time.sleep(60)

            newinfo = self.HabrAgrNew(q,allinfo)
            if newinfo!=None:
                print('NEW:')
                q.put(newinfo)

            newinfo = self.TprogerAgrNew(q,allinfo)
            if newinfo!=None:
                print('NEW:')
                q.put(newinfo)

            newinfo = self.SOFAgrNew(q,allinfo) 
            if newinfo!=None:
                print('NEW:')
                q.put(newinfo)   

            newinfo = self.IchipAgrNew(q,allinfo) 
            if newinfo!=None:
                print('NEW:')
                q.put(newinfo)         

    #Функция обёртка, запускает ввод в очередь всех имеющихся новостей 
    def AgregateAll(self,q):
        self.HabrAgregate(q)
        self.TprogerAgregate(q)
        self.SOFAgregate(q)
        self.IchipAgregate(q)   

#Очередь "Last In, First Out" используется, чтобы последними передавались самые новые статьи
q=queue.LifoQueue()

#Создание класса агрегатора
ITAgregator=Agregator()
#Вывод всех имеющихся на сайтах новостей
ITAgregator.AgregateAll(q)

#СПИСОК уже выведенных на экран новостей
allinfo = []
while not q.empty():
    info = q.get()
    allinfo.append(info)
    for inf in info:
        print(inf)
    print("-----------------------------------------------------\n")

#Запуск фонового потока для поиска новых статей на сайтах
t=threading.Thread(target=ITAgregator.AgregateNewAll,args=(q,allinfo), daemon = True)
t.start()

while True:
    print("Waiting for news")
    #q.get() ожидает,пока в очереди появится новая задача(новый элемент)
    info = q.get()
    allinfo.append(info)
    for inf in info:
        print(inf)
    print("-----------------------------------------------------\n")



