package com.example.fifthlab

import android.annotation.SuppressLint
import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxHeight
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.material3.Button
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.material3.TextField
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.saveable.rememberSaveable
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import com.example.fifthlab.ui.theme.FifthLabTheme

class MainActivity : ComponentActivity() {
    private val firstScreenViewModel = FirstScreenViewModel()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContent {
            FifthLabTheme {
                Surface(
                    modifier = Modifier.fillMaxSize(),
                    color = MaterialTheme.colorScheme.background
                ) {
                    Program()
                }
            }
        }
    }

    @Composable
    fun Program() {
        val numberState = remember { mutableStateOf("") }
        val res = remember { mutableStateOf("") }
        Box(modifier = Modifier.fillMaxSize(), contentAlignment = Alignment.TopCenter){
            Column(horizontalAlignment = Alignment.CenterHorizontally, modifier = Modifier
                .fillMaxSize()
                .padding(8.dp))
            {
                TextField(
                    value = numberState.value,
                    onValueChange = {numberState.value = it},
                    modifier = Modifier
                        .fillMaxWidth()
                        .fillMaxHeight(0.1f)
                )
                Spacer(modifier = Modifier.fillMaxSize(0.3f))
                Button(
                    onClick = {
                        firstScreenViewModel.enterPhoneNumber(numberState.value);
                        when (firstScreenViewModel.uiState) {
                            is FirstScreenState.Loading -> {}
                            is FirstScreenState.Success -> {
                                res.value = ((firstScreenViewModel.uiState as FirstScreenState.Success).value)
                            }
                            is FirstScreenState.Error -> {
                                res.value = ((firstScreenViewModel.uiState as FirstScreenState.Error).error)
                            }
                        }
                    },
                    modifier = Modifier
                        .fillMaxWidth()
                        .align(Alignment.CenterHorizontally),
                )
                {
                    Text(text = "Set the phone number", fontSize = 24.sp)
                }
                Spacer(modifier = Modifier.fillMaxSize(0.1f))
                Box(modifier = Modifier
                    .fillMaxWidth().fillMaxHeight(0.3f)
                    .background(color = Color.Gray),
                    contentAlignment = Alignment.Center)
                {
                    Text(text = res.value, fontSize = 24.sp)
                }


            }
        }

    }
}

