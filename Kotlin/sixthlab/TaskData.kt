package com.example.sixthlab

import java.time.LocalDate

class TaskData(private val dataTask: HashMap<Int, Task> ) {
    private var id = 0;

    constructor() : this(HashMap()) {
        val data = mapOf(
            id++ to Task(
                "Приготовить поесть",
                "Паста с грибами и курицей под сыром?",
                LocalDate.of(2024, 4, 11),
                Priority.VERY_HIGH
            ),
            id++ to Task(
                "Сдать зачётку в деканат",
                "Здание СФТИ, до двух часов дня отдать старосте, он передаст",
                LocalDate.of(2024, 4, 10),
                Priority.HIGH
            ),
            id++ to Task(
                "Распланировать время на следующую неделю",
                "Нужно наладить адекватный режим и начать высыпаться",
                LocalDate.of(2024, 4, 15),
                Priority.LOW
            ),
            id++ to Task(
                "делать лабораторные по мобильной разработке",
                "Нужно закрыть долги перед сдачей диплома",
                LocalDate.of(2024, 4, 10),
                Priority.VERY_HIGH
            ),
            id++ to Task(
                "Зайти к родителям",
                "Ждут на чай",
                LocalDate.of(2024, 4, 13),
                Priority.MEDIUM
            ),
        )

        for (item in data) {
            dataTask[item.key] = item.value;
        }
    }

    operator fun set(id: Int, task: Task) {
        dataTask[id] = task;
    }

    fun add(task: Task) {
        dataTask[id++] = task;
    }

    fun checkDataSize() : Int {
        return dataTask.size;
    }

    fun delete(id: Int) {
        dataTask.remove(id);
    }

    fun getTask(id: Int): Task? {
        return dataTask[id];
    }

    fun getTasks() : Map<Int, Task> {
        return dataTask;
    }

    fun updateTask(id: Int, task: Task) {
        dataTask[id] = task;
    }

    fun toggleTaskCompletion(id: Int) {
        dataTask[id]?.isTaskComplete?.value = !dataTask[id]?.isTaskComplete?.value!!;
    }

}