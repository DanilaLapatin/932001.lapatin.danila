package com.example.sixthlab

import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableIntStateOf
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.setValue
import androidx.lifecycle.ViewModel
import androidx.navigation.NavController

enum class MainScreenState {
    EMPTY,
    NOT_EMPTY
}

class TaskViewModel(val navController: NavController) : ViewModel() {
    var selectedTask by mutableIntStateOf(0);
    //    private var mainScreenState by mutableStateOf(MainScreenState.EMPTY);
    private val taskData = TaskData();

//    fun checkMainScreenState() : String {
//        return mainScreenState.name;
//    }

    fun addTask(task: Task) {
        taskData.add(task);
    }

    fun toggleTaskCompletion(id: Int) {
        taskData.toggleTaskCompletion(id);
    }

    fun getTasks() : Map<Int, Task> {
        return taskData.getTasks();
    }

    fun getTask(id: Int) : Task? {
        return taskData.getTask(id);
    }

    fun deleteTask(id: Int) {
        taskData.delete(id);
    }

    fun checkTasksSize() : Int{
        return taskData.checkDataSize();
    }

    fun selectTask(id: Int) {
        selectedTask = id;
        navController.navigate(Screens.DETAILS_SCREEN.name);
    }

    fun createTask() {
        navController.navigate(Screens.CREATION_SCREEN.name)
    }

    fun getSelectedTask() : Task? {
        return taskData.getTask(selectedTask);
    }

    fun updateSelectedTask(task: Task) {
        taskData.updateTask(selectedTask, task);
    }


}
