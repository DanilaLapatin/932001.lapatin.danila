package com.example.sixthlab

import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.layout.wrapContentHeight
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material3.Button
import androidx.compose.material3.ButtonDefaults
import androidx.compose.material3.ExperimentalMaterial3Api
import androidx.compose.material3.Icon
import androidx.compose.material3.OutlinedTextField
import androidx.compose.material3.Text
import androidx.compose.material3.TextField
import androidx.compose.material3.TextFieldDefaults
import androidx.compose.material3.rememberDatePickerState
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import com.example.sixthlab.ui.theme.BLUE
import com.example.sixthlab.ui.theme.GREEN
import com.example.sixthlab.ui.theme.RED
import java.time.Instant
import java.time.LocalDateTime
import java.time.ZoneId
import java.time.format.DateTimeFormatter
import java.time.temporal.ChronoUnit
import kotlin.time.Duration.Companion.days

@Composable
fun ScreenMain(viewModel: TaskViewModel,  onCreate: () -> Unit = {}) {
    if (viewModel.checkTasksSize() != 0) {
        NotEmptyMainScreen(viewModel, onCreate)
    }
    else {
        EmptyMainScreen(viewModel, onCreate)
    }
}

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun ScreenDetails(viewModel: TaskViewModel) {
    val task = viewModel.getSelectedTask()!!

    Column(verticalArrangement = Arrangement.SpaceBetween) {
        NavigationHeader("Заметка", onClick = {viewModel.navController.navigate(Screens.MAIN_SCREEN.name)})
        Column(
            modifier = Modifier
                .fillMaxWidth()
                .padding(16.dp)
        ) {
            Row(
                horizontalArrangement = Arrangement.SpaceBetween,
            ) {
                Box(modifier = Modifier.weight(0.9f)){
                    Text(
                        text = task.header,
                        fontSize = 32.sp,
                        fontWeight = FontWeight.Bold,

                        )
                }
                Button(
                    onClick = {
                        viewModel.navController.navigate(Screens.EDITION_SCREEN.name)
                    },
                    colors = ButtonDefaults.buttonColors(
                        contentColor = Color.Black,
                        containerColor = Color.White
                    ),
                ) {
                    Icon(painter = painterResource(id = R.drawable.edit_24px_outlined), contentDescription = "edit", modifier = Modifier.size(24.dp))
                }

            }
            Text(
                text = if (task.isTaskComplete.value) "Выполнено" else "Не выполнено",
                color = if (task.isTaskComplete.value) GREEN else RED,
                fontSize = 16.sp,
                modifier = Modifier
                    .padding(0.dp, 0.dp, 0.dp, 16.dp)
                    .align(Alignment.End)

            )
            Text(
                text = task.description,
                fontSize = 20.sp,
                color = Color.Black,
                modifier = Modifier.padding(0.dp, 0.dp, 0.dp, 16.dp)
            )
            Row(
                verticalAlignment = Alignment.CenterVertically
            ) {
                Box(modifier = Modifier.weight(0.8f)){
                    Icon(
                        painter = painterResource(
                            id = R.drawable.query_builder_24px_outlined
                        ),
                        contentDescription = "clocks",
                        modifier = Modifier.size(24.dp)
                    )
                    Text(
                        text = "До " + task.timeToComplete.format(DateTimeFormatter.ofPattern("dd.MM.yyyy")),
                        fontSize = 20.sp,
                        color = Color.Gray,
                        textAlign = TextAlign.Left,
                        modifier = Modifier.padding(32.dp, 0.dp)
                    )
                }
                Text(
                    text = priorityRussian[task.priority]!!,
                    fontWeight = FontWeight.Medium,
                    textAlign = TextAlign.Center,
                    modifier = Modifier
                        .background(
                            priorityColors[task.priority] ?: Color.Black,
                            shape = RoundedCornerShape(8.dp)
                        )
                        .height(32.dp)
                        .wrapContentHeight()
                        .padding(4.dp)
                )
            }


            Spacer(modifier = Modifier.weight(1.0f))


        }
    }
}

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun ScreenCreation(viewModel: TaskViewModel) {
    var headerState by remember{ mutableStateOf("") }
    var descriptionState by remember{ mutableStateOf("") }
    var datePickerState = rememberDatePickerState()
    var priorityToTaskState = remember {mutableStateOf(Priority.LOW)}
    var isExpandedState = remember { mutableStateOf(false) }

    Column(
        horizontalAlignment = Alignment.Start,
        verticalArrangement = Arrangement.SpaceBetween,
        modifier = Modifier.fillMaxSize()
    ) {
        NavigationHeader("Добавить заметку", onClick = {viewModel.navController.navigate(Screens.MAIN_SCREEN.name)})
        Column(
            modifier = Modifier
                .fillMaxWidth()
                .padding(16.dp)
        ) {
            Text(
                text = "Заголовок",
                fontWeight = FontWeight.Medium,
                fontSize = 20.sp,
            )
            TextField(
                value = headerState,
                onValueChange = { headerState = it },
                modifier = Modifier
                    .fillMaxWidth()
                    .padding(0.dp, 0.dp, 0.dp, 16.dp),
                colors = TextFieldDefaults.colors(
                    focusedContainerColor = Color.Transparent,
                    unfocusedContainerColor = Color.Transparent,
                    focusedIndicatorColor = BLUE,
                    cursorColor = BLUE,
                )
            )
            OutlinedTextField(
                value = descriptionState,
                onValueChange = {
                    descriptionState = it
                },
                modifier = Modifier
                    .fillMaxWidth(),
                colors = TextFieldDefaults.colors(
                    focusedContainerColor = Color.Transparent,
                    unfocusedContainerColor = Color.Transparent,
                    focusedIndicatorColor = BLUE,
                    cursorColor = BLUE,
                ),
                label = {
                    Text(text = "Описание")
                },
                minLines = 3,
                maxLines = 5,
                shape = RoundedCornerShape(8.dp)
            )
        }
        Text(
            text = "${descriptionState.length}",
            textAlign = TextAlign.Right,
            modifier = Modifier
                .fillMaxWidth()
                .padding(0.dp, 0.dp, 16.dp, 0.dp),
        )
//        TextField(
//            value = datePickerState.toString(),
//            onValueChange = { newValue -> datePickerState = newValue },
//            modifier = Modifier
//                .fillMaxWidth()
//                .padding(0.dp, 0.dp, 0.dp, 16.dp),
//            colors = TextFieldDefaults.colors(
//                focusedContainerColor = Color.Transparent,
//                unfocusedContainerColor = Color.Transparent,
//                focusedIndicatorColor = BLUE,
//                cursorColor = BLUE,
//            )
//        )

        DatePickerComposable(datePickerState)
        DropDownField(priorityToTaskState, isExpandedState = isExpandedState)

        Spacer(modifier = Modifier.weight(0.5f))
        Button(
            onClick = {
                if (headerState.isNotBlank() && descriptionState.isNotBlank()) {
                    viewModel.addTask(Task(
                        headerState,
                        descriptionState,
                        Instant.ofEpochMilli(
                            datePickerState.selectedDateMillis ?:
                            Instant
                                .now()
                                .toEpochMilli()).atZone(
                            ZoneId.systemDefault()).toLocalDate(),
                        priority = priorityToTaskState.value
                    ))
                    viewModel.navController.navigate(Screens.MAIN_SCREEN.name)
                }
            },
            colors = ButtonDefaults.buttonColors(
                containerColor = Color.Black,
                contentColor = Color.White
            ),
            modifier = Modifier
                .weight(0.1f)
//                .padding(16.dp)
        ) {
            Text(
                text = "Сохранить",
                fontSize = 16.sp,
                modifier = Modifier
                    .fillMaxSize()
                    .wrapContentHeight(),
                textAlign = TextAlign.Center
            )
        }
        Spacer(modifier = Modifier.size(60.dp))
    }
}

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun ScreenEdition(viewModel: TaskViewModel) {
    val selected = viewModel.getSelectedTask()

    var headerState by remember{ mutableStateOf(selected?.header) }
    var descriptionState by remember{ mutableStateOf(selected?.description) }
    var datePickerState = rememberDatePickerState()
    var priorityToTaskState = remember { selected?.let { mutableStateOf(it.priority) } }
    var isExpandedState = remember { mutableStateOf(false) }

    Column(
        horizontalAlignment = Alignment.Start,
        verticalArrangement = Arrangement.SpaceBetween,
        modifier = Modifier.fillMaxSize()
    ) {
        NavigationHeader(
            "Добавить заметку",
            onClick = { viewModel.navController.navigate(Screens.MAIN_SCREEN.name) }
        )
        Column(
            modifier = Modifier
                .fillMaxWidth()
                .padding(16.dp)
        ) {
            Text(
                text = "Заголовок",
                fontWeight = FontWeight.Medium,
                fontSize = 20.sp,
            )
            TextField(
                value = headerState!!,
                onValueChange = { headerState = it },
                modifier = Modifier
                    .fillMaxWidth()
                    .padding(0.dp, 0.dp, 0.dp, 16.dp),
                colors = TextFieldDefaults.colors(
                    focusedContainerColor = Color.Transparent,
                    unfocusedContainerColor = Color.Transparent,
                    focusedIndicatorColor = BLUE,
                    cursorColor = BLUE,
                )
            )
            OutlinedTextField(
                value = descriptionState!!,
                onValueChange = {
                    descriptionState = it
                },
                modifier = Modifier
                    .fillMaxWidth(),
                colors = TextFieldDefaults.colors(
                    focusedContainerColor = Color.Transparent,
                    unfocusedContainerColor = Color.Transparent,
                    focusedIndicatorColor = BLUE,
                    cursorColor = BLUE,
                ),
                label = {
                    Text(text = "Описание")
                },
                minLines = 3,
                maxLines = 5,
                shape = RoundedCornerShape(8.dp)
            )
        }
        Text(
            text = "${descriptionState?.length}",
            textAlign = TextAlign.Right,
            modifier = Modifier
                .fillMaxWidth()
                .padding(0.dp, 0.dp, 16.dp, 0.dp),
        )
        DatePickerComposable(datePickerState)
        if (priorityToTaskState != null) {
            DropDownField(priorityToTaskState, isExpandedState = isExpandedState)
        }
        Spacer(modifier = Modifier.weight(0.5f))
        Button(
            onClick = {
                if (headerState!!.isNotBlank() && descriptionState!!.isNotBlank()) {
                    if (priorityToTaskState != null) {
                        viewModel.updateSelectedTask(Task(
                            headerState!!,
                            descriptionState!!,
                            Instant.ofEpochMilli(
                                datePickerState.selectedDateMillis ?: Instant
                                    .now()
                                    .toEpochMilli()).atZone(
                                ZoneId.systemDefault()).toLocalDate(),
                            priority = priorityToTaskState.value
                        ))
                    }
                    viewModel.navController.navigate(Screens.MAIN_SCREEN.name)
                }
            },
            colors = ButtonDefaults.buttonColors(
                containerColor = Color.Black,
                contentColor = Color.White
            ),
            modifier = Modifier
                .weight(0.1f)
//                .padding(16.dp)
        ) {
            Text(
                text = "Сохранить",
                fontSize = 16.sp,
                modifier = Modifier
                    .fillMaxSize()
                    .wrapContentHeight(),
                textAlign = TextAlign.Center
            )
        }
        Spacer(modifier = Modifier.size(60.dp))


    }
}


