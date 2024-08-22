package com.example.sixthlab
import androidx.compose.runtime.MutableState
import androidx.compose.runtime.mutableStateOf
import com.example.sixthlab.ui.theme.BLUE
import com.example.sixthlab.ui.theme.GREEN
import com.example.sixthlab.ui.theme.RED
import com.example.sixthlab.ui.theme.YELLOW
import java.time.LocalDate

enum class Priority {
    LOW,
    MEDIUM,
    HIGH,
    VERY_HIGH
}

val priorityRussian = mapOf(
    Priority.LOW to "Несрочно",
    Priority.MEDIUM to "Средне",
    Priority.HIGH to "Срочно",
    Priority.VERY_HIGH to "Очень срочно"
)

val priorityColors = mapOf(
    Priority.LOW to GREEN,
    Priority.MEDIUM to YELLOW,
    Priority.HIGH to RED,
    Priority.VERY_HIGH to BLUE
)

data class Task (
    val header : String,
    val description: String,
    val timeToComplete: LocalDate,
    val priority: Priority,
    var isTaskComplete : MutableState<Boolean> = mutableStateOf(false),
) {
    fun toggleCompletion() {
        isTaskComplete.value = !isTaskComplete.value
    }
}

