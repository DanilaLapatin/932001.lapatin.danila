package com.example.sixthlab

import androidx.compose.foundation.Image
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxHeight
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.layout.wrapContentHeight
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material3.Button
import androidx.compose.material3.ButtonDefaults
import androidx.compose.material3.Card
import androidx.compose.material3.Checkbox
import androidx.compose.material3.CheckboxDefaults
import androidx.compose.material3.DatePicker
import androidx.compose.material3.DatePickerDefaults
import androidx.compose.material3.DatePickerDialog
import androidx.compose.material3.DatePickerState
import androidx.compose.material3.DropdownMenuItem
import androidx.compose.material3.ExperimentalMaterial3Api
import androidx.compose.material3.ExposedDropdownMenuBox
import androidx.compose.material3.ExposedDropdownMenuDefaults
import androidx.compose.material3.Icon
import androidx.compose.material3.MenuDefaults
import androidx.compose.material3.Text
import androidx.compose.material3.TextButton
import androidx.compose.material3.TextField
import androidx.compose.material3.TextFieldDefaults
import androidx.compose.runtime.Composable
import androidx.compose.runtime.MutableState
import androidx.compose.runtime.derivedStateOf
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.shadow
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.layout.ContentScale
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import java.time.Instant
import java.time.ZoneId
import java.time.format.DateTimeFormatter


@Composable
fun EmptyMainScreen(viewModel: TaskViewModel, onCreate: () -> Unit = {}) {
    Box(modifier = Modifier.fillMaxSize()) {
        Header()
        EmptyPlaceHolder();
        CreateButton(modifier = Modifier, onCreate)
    }
}

@Composable
fun Header() {
    Box(
        modifier = Modifier
            .fillMaxWidth()
            .padding(32.dp),
        contentAlignment = Alignment.Center
    ) {
        Text(
            text = "Не забыть",
            fontSize = 24.sp
        )
    }
}

@Composable
fun EmptyPlaceHolder() {
    val img = R.drawable.emptyscreenbackground
    Column(
        verticalArrangement = Arrangement.SpaceAround,
        horizontalAlignment = Alignment.CenterHorizontally,
        modifier = Modifier
            .fillMaxSize()
            .padding(16.dp)
    ) {
        Spacer(modifier = Modifier.weight(1.0f))
        Image(
            contentScale = ContentScale.Crop,
            painter = painterResource(id = img),
            contentDescription = "empty_background",
            modifier = Modifier
                .fillMaxWidth()
        )
        Text(
            text = "Пока что у вас нет никаких дел.",
            textAlign = TextAlign.Center,
            fontSize = 20.sp,
            modifier = Modifier
                .fillMaxWidth()
        )
        Text(
            text = "Хорошего отдыха!",
            textAlign = TextAlign.Center,
            fontSize = 20.sp,
            modifier = Modifier
                .fillMaxWidth()
        )
        Spacer(modifier = Modifier.weight(1.0f))
    }
}

@Composable
fun CreateButton(modifier: Modifier, onCreate: () -> Unit = {}) {
    Box(modifier = Modifier.fillMaxSize()) {
        Button(
            onClick = onCreate,
            shape = RoundedCornerShape(24.dp),
            modifier = Modifier
                .size(90.dp)
                .shadow(24.dp, shape = RoundedCornerShape(24.dp), ambientColor = Color.Black)
                .align(Alignment.BottomEnd)
                .padding(0.dp, 0.dp, 16.dp, 16.dp),
            colors = ButtonDefaults.buttonColors(
                containerColor = Color.Black,
                contentColor = Color.White
            )

        ) {
            Text(
                text = "+",
                fontSize = 34.sp
            )
        }
    }
}

@Composable
fun NotEmptyMainScreen(viewModel: TaskViewModel, onCreate: () -> Unit = {}) {
    Box(modifier = Modifier.fillMaxSize()) {
        Column(verticalArrangement = Arrangement.Top, modifier = Modifier.padding(0.dp, 0.dp, 0.dp, 128.dp)) {
            Header()
            TaskList(viewModel)
        }
        CreateButton(modifier = Modifier, onCreate)
    }
}

@Composable
fun TaskList(viewModel: TaskViewModel) {
    Column(
        modifier = Modifier
            .fillMaxSize()
            .padding(16.dp)
    ) {
        Text(
            text = "Задачи",
            fontWeight = FontWeight.Bold,
            textAlign = TextAlign.Left,
            fontSize = 32.sp,
            modifier = Modifier
                .fillMaxWidth()
                .padding(8.dp),
        )
        LazyColumn {
            val tasksList = viewModel.getTasks().toList()

            items(tasksList) { (key, task) ->
                Task(task) {
                    viewModel.selectTask(key);
                }
            }
        }
    }
}

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun Task(task: Task, onClick: () -> Unit = {}) {
    Card(
        onClick = onClick,
        modifier = Modifier
            .fillMaxWidth()
            .padding(8.dp)
    ) {
        val taskColor =  priorityColors[task.priority] ?: Color.Gray;
        Row(
            horizontalArrangement = Arrangement.Absolute.SpaceAround,
            modifier = Modifier
                .fillMaxSize()
                .background(color = taskColor)
                .padding(16.dp, 8.dp, 32.dp, 8.dp)
        ) {
            Column(modifier = Modifier
                .fillMaxHeight()
                .weight(0.9f)) {
                Text(
                    text = task.header,
                    fontSize = 20.sp,
                    fontWeight = FontWeight.Bold,
                    color = Color.White
                )
                Text(
                    text = task.description,
                    fontSize = 16.sp,
                    color = Color.White
                )
            }
            Checkbox(
                checked = task.isTaskComplete.value,
                onCheckedChange = {
                    task.toggleCompletion()
                },
                colors = CheckboxDefaults.colors(
                    checkedColor = Color.White,
                    uncheckedColor = Color.White,
                    checkmarkColor = taskColor,
                ),
                modifier = Modifier
                    .fillMaxHeight()
                    .padding(16.dp, 0.dp)
                    .weight(0.05f)
                    .align(Alignment.CenterVertically)
            )
        }
    }
}

@Composable
fun NavigationHeader(text: String, onClick: () -> Unit = {}) {
    Row(
        verticalAlignment = Alignment.CenterVertically,
        modifier = Modifier
            .fillMaxWidth()
            .height(64.dp)
    ){
        Button(
            onClick = onClick,
            colors = ButtonDefaults.buttonColors(
                contentColor = Color.Black,
                containerColor = Color.White,
            )
        ) {
            Icon(painter = painterResource(id = R.drawable.arrow), contentDescription = "arrow_button", modifier = Modifier.size(18.dp))
        }
        Text(
            text = text,
            fontSize = 28.sp,
            textAlign = TextAlign.Left,
            modifier = Modifier
                .fillMaxSize()
                .wrapContentHeight(align = Alignment.CenterVertically)
        )

    }
}

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun DatePickerComposable(datePickerState: DatePickerState) {
    val isOpen = remember {
        mutableStateOf(false)
    }
    val isDateChosen = remember {
        derivedStateOf {
            datePickerState.selectedDateMillis != null
        }
    }
    Row(
        verticalAlignment = Alignment.CenterVertically,
        horizontalArrangement = Arrangement.SpaceBetween,
        modifier = Modifier
            .fillMaxWidth()
            .padding(16.dp)
    ) {
        Text(
            text =
            if (isDateChosen.value)
                Instant.ofEpochMilli(datePickerState.selectedDateMillis!!)
                    .atZone(
                        ZoneId.systemDefault()
                    )
                    .toLocalDate()
                    .format(DateTimeFormatter.ofPattern("dd.MM.yyyy"))
            else
                Instant.now()
                    .atZone(
                        ZoneId.systemDefault()
                    )
                    .toLocalDate()
                    .format(DateTimeFormatter.ofPattern("dd.MM.yyyy")),
        )
        Button(
            colors = ButtonDefaults.buttonColors(
                contentColor = Color.Black,
                containerColor = Color.White
            ),
            onClick = {
                isOpen.value = true
            },
        ) {
            Icon(
                painterResource(id = R.drawable.date_range_24px_outlined),
                contentDescription = "datePicker",
                modifier = Modifier.size(28.dp)
            )
        }
    }
    if (isOpen.value) {
        DatePickerDialog(
            colors = DatePickerDefaults.colors(
                containerColor = Color.White,
                titleContentColor = Color.Black,
                weekdayContentColor = Color.Black,
                headlineContentColor = Color.Black,
                subheadContentColor = Color.Black,
                yearContentColor = Color.Black,
                currentYearContentColor = Color.Black,
                dayInSelectionRangeContentColor = Color.Black,
                todayDateBorderColor = Color.Black,
                todayContentColor = Color.Black,
                selectedDayContainerColor = Color.Black,
                selectedDayContentColor = Color.White,
                selectedYearContentColor = Color.White,
                dayContentColor = Color.Black,
                disabledDayContentColor = Color.Black,
            ),
            dismissButton = {
                TextButton(
                    onClick = {
                        isOpen.value = false
                    },
                    colors = ButtonDefaults.buttonColors(
                        contentColor = Color.Black,
                        containerColor = Color.Transparent,
                    )
                ) {
                    Text(
                        text = "Отмена",
                        fontWeight = FontWeight.Bold,
                    )
                }
            },
            onDismissRequest = {
                isOpen.value = false
            },
            confirmButton = {
                TextButton(
                    onClick = {
                        isOpen.value = false
                    },
                    enabled = isDateChosen.value,
                    colors = ButtonDefaults.buttonColors(
                        contentColor = Color.Black,
                        containerColor = Color.Transparent,
                    )
                ) {
                    Text(
                        text = "OK",
                        fontWeight = FontWeight.Bold
                    )
                }
            },

            ) {
            DatePicker(
                state = datePickerState,
                colors = DatePickerDefaults.colors(
                    containerColor = Color.White,
                    titleContentColor = Color.Black,
                    weekdayContentColor = Color.Black,
                    headlineContentColor = Color.Black,
                    subheadContentColor = Color.Black,
                    yearContentColor = Color.Black,
                    currentYearContentColor = Color.Black,
                    dayInSelectionRangeContentColor = Color.Black,
                    todayDateBorderColor = Color.Black,
                    todayContentColor = Color.Black,
                    selectedDayContainerColor = Color.Black,
                    selectedDayContentColor = Color.White,
                    selectedYearContentColor = Color.White,
                    dayContentColor = Color.Black,
                    disabledDayContentColor = Color.Black,
                )
            )
        }
    }
}

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun DropDownField(
    priorityToTaskState: MutableState<Priority>,
    isExpandedState: MutableState<Boolean>,
    modifier: Modifier = Modifier
) {
    ExposedDropdownMenuBox(
        expanded = isExpandedState.value,
        onExpandedChange = {
            isExpandedState.value = !isExpandedState.value
        },
        modifier = Modifier.fillMaxWidth()
    ) {
//        Box(
//            modifier = Modifier
//                .fillMaxWidth()
////                .padding(16.dp)
//                .menuAnchor(),
//            contentAlignment = Alignment.Center
//        ) {

        TextField(
            value = priorityToTaskState.value.name,
            onValueChange = {},
            readOnly = true,
            trailingIcon = { ExposedDropdownMenuDefaults.TrailingIcon(expanded = isExpandedState.value) },
            colors = TextFieldDefaults.colors(
                focusedTextColor = Color.Black,
                focusedContainerColor = Color.LightGray,
                unfocusedTextColor = Color.DarkGray,
                unfocusedContainerColor = Color.LightGray,
                unfocusedPlaceholderColor = Color.LightGray,
                focusedPlaceholderColor = Color.Black
            ),
            modifier = Modifier
                .fillMaxWidth()
                .menuAnchor()
                .padding(16.dp)
        )


        ExposedDropdownMenu(
            expanded = isExpandedState.value,
            onDismissRequest = {
                isExpandedState.value = !isExpandedState.value
            },
            modifier = Modifier
                .background(Color.LightGray)
        ) {
            for (item in Priority.entries) {
                DropdownMenuItem(
                    text = { priorityRussian[item]?.let { Text(text = it) } },
                    modifier = Modifier
                        .background(Color.LightGray)
                        .align(Alignment.CenterHorizontally),
                    colors = MenuDefaults.itemColors(
                        textColor = Color.Black,
                    ),
                    onClick = {
                        priorityToTaskState.value = item
                        isExpandedState.value = false
                    },
                )
            }
//            }
        }
    }
}

//@Composable
//fun SaveButton(
//    headerState: MutableState<String>,
//    descriptionState: MutableState<String>,
//
//) {
//
//}