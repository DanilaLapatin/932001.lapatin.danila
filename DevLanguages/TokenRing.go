package main
import (
    "fmt"//Ввод-вывод
	"math/rand"//Математика для генерации случайных чисел
	"time"//Время для создания задержки
	"strconv"//Конвертация в строки
)
//Программа для эмуляции протокола передачи данных в локальной вычислительной сети TokenRing
//func main() программы содержит бесконечный цикл for{}!!! Выключается через Ctrl+C 

//Структура-сообщение, содержащая данные, конечного получателя и время жизни сообщения
type Token struct {
    data string
	recipient int
	ttl int
}



func main() {
	for {
		var N int//Число узлов (горутин)
        fmt.Print("Введите число узлов: ")
	    fmt.Scan(&N)
	    var firstsender int//Узел, который первым получит ссылку на экземпляр структуры Token и начнёт пересылку между узлами
	    fmt.Print("Введите Начальный узел (целое положительное число меньше числа узлов): ")
	    fmt.Scan(&firstsender)
	    for firstsender >= N || firstsender < 0 {
		    fmt.Println("Введите Начальный узел (целое положительное число меньше числа узлов): ")
		    fmt.Scan(&firstsender)
	    }

	    //канал, через который в TokenRing будет запущено сообщение. Номера каналов соответствуют ПРЕДШЕСТВУЮЩИМ им горутинам
		var startchannel int

	    if firstsender == 0 {
		    startchannel = N-1
	    } else {
		    startchannel = firstsender-1
	    }
	    var ttl int
	    var recipient int
	    ttl = rand.Intn(N/2)+N/2//Время жизни задано как случайное число, минимально равное половине от количества узлов(горутин)
	    recipient = rand.Intn(N)
		//Перебираем числа, пока получатель не станет отличаться от начального узла
	    for recipient == firstsender {
		    recipient = rand.Intn(N)
	    }
	    //переменная data будет содержать информацию о пересылках сообщения(а точнее, ссылки на него) между узлами
	    data := ""
	    //strconv.Itoa(х) конвертирует х в string
	    fmt.Println("Создано сообщение: получатель - "+strconv.Itoa(recipient)+", время жизни = "+strconv.Itoa(ttl))
	    var t Token = Token{data,recipient,ttl}
	    var chans = make([]chan *Token,N)//Задаётся массив каналов, передающих указатель на Token, размера N
	    for i, _ := range chans {
		    chans[i] = make(chan *Token)
        }
        go Sender(0,chans[N-1],chans[0],firstsender)
		//<-time.After(time.Second * 1)
	    for i := 1; i < N; i++ {	
		    go Sender(i,chans[i-1],chans[i],firstsender)
			/*<-time.After(time.Second * 1) эта строка затормозила и упорядочила бы выполнение программы,
			 заставив горутины включаться последовательно с интервалом  в  1 секунду*/
	    }
	    chans[startchannel]<-&t //Пересылаем из main по каналу с индексом startchannel ссылку на экземпляр Token
		<-time.After(time.Second * time.Duration(5))
		if N >100 {
			<-time.After(time.Second * time.Duration(10))
		}
	     //Ждём некоторое время, пока выводятся данные в консоль, чтобы последующий вывод не сбился
    }
	
}

//Функция, которая будет запускаться в легковесных потоках, горутинах, которые в этой задаче играют роль узлов TokenRing
//Принимает номер узла, входящий и исходящий каналы, а так же номер первого узла в цепочке пересылки
func Sender (i int, chprev chan *Token, chnext chan *Token,firstsender int) {
	fmt.Println("Узел "+strconv.Itoa(i)+ " начал работу!")
	//<-time.After(time.Second * time.Duration(N+1))
	token:=<-chprev
	//Если сообщение пришло получателю, выводим данные сообщения
	if token.recipient == i {
		token.data+=strconv.Itoa(i)
		fmt.Println("Узел "+strconv.Itoa(i)+" получил сообщение")
		fmt.Println(" Данные о порядке пересылки - "+token.data)
		return
	}
	//Если узел- начальный, то не нужно уменьшать время жизни на 1
	if i != firstsender {
		token.ttl-=1
	}
	//Если время жизни истекло, то вывод данных
	if 	token.ttl == 0 {
		token.data+=strconv.Itoa(i)
		fmt.Println("Время жизни сообщения истекло на узле "+strconv.Itoa(i)+", сообщение не дошло до получателя - узла "+strconv.Itoa(token.recipient))
		fmt.Println(" Данные о порядке пересылки - "+token.data)
			return
	}
	//Добавление данных о ходе пересылки
	token.data+=strconv.Itoa(i)+"->"
	fmt.Println("Узел "+strconv.Itoa(i)+" пересылает сообщение следующему узлу...")
	//Пересылка в следующий узел по каналу chnext
	chnext<-token

}
