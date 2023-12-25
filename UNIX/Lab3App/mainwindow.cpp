#include "mainwindow.h"
#include "ui_mainwindow.h"

#include <cstdlib>
#include <iostream>
#include <ctime>
#include <math.h>
#include<array>


using namespace std;

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    srand(time(NULL));
}

MainWindow::~MainWindow()
{
    delete ui;
}

QString ArrResponse[21] = {
    "Бесспорно", "Предрешено", "Никаких сомнений", "Оперделенно да", "Можешь быть уверен в этом",
    "Мне кажется да", "Вероятнее всего", "Хорошие перспективы", "Знаки говорят - да", "Да",
    "Пока не ясно, попробуй снова", "Спроси позже", "Лучше не рассказывать", "Сейчас нельзя предсказать", "Сконцентрируйся и спроси опять",
    "Даже не думай", "Мой ответ — «нет»", "По моим данным — «нет»", "Перспективы не очень хорошие", "Весьма сомнительно"};


void MainWindow::on_pushButton_clicked()
{
        srand(time(NULL));

        int numResponse = rand()%21;
        cout << "Random number = " << numResponse << endl;
        ui->label_2->setText(ArrResponse[numResponse]);

}



void MainWindow::on_pushButton_2_clicked()
{

    double Prob = 0.5;
    double num=(rand() / (RAND_MAX + 1.));
    cout << "Random number(2) = " << num << endl;
    if(num > Prob)
    {
        ui->label_4->setText("Yes!");
    }

    if(num == Prob)
    {
        ui->label_4->setText("Don't know, try again");
    }
    if(num < Prob)
    {
        ui->label_4->setText("No");
    }
}

