package com.example.thirdlab

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material3.Button
import androidx.compose.material3.ButtonDefaults
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.material3.TextField
import androidx.compose.runtime.Composable
import androidx.compose.runtime.mutableIntStateOf
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.paint
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.layout.ContentScale
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import com.example.thirdlab.ui.theme.ThirdLabTheme
import com.example.thirdlab.ui.theme.MainColor
import com.example.thirdlab.ui.theme.SecondColor

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContent {
            ThirdLabTheme {
                Surface(
                    modifier = Modifier.fillMaxSize(),
                    color = MaterialTheme.colorScheme.background
                ) {
                    Game()
                }
            }
        }
    }
}

@Composable
fun Game(modifier: Modifier = Modifier) {
    val winNum = remember { mutableIntStateOf(0) };
    val name = remember {
        mutableStateOf("")
    }

    when (winNum.intValue) {
        0 -> {
            Box(
                modifier = with (Modifier) {
                    fillMaxSize()
                        .paint(
                            painterResource(id = R.drawable.backgroundfirst),
                            contentScale = ContentScale.FillBounds
                        )

                })
            {
                Column() {
                    Spacer(modifier = modifier.size(164.dp))

                    Box(
                        contentAlignment = Alignment.TopCenter,
                        modifier = modifier
                            .background(color = MainColor)
                            .fillMaxWidth()
                            .height(106.dp)
                    ) {
                        Text(
                            text = "My Visual Novel",
                            color = Color.White,
                            fontSize = 36.sp,
                            modifier = modifier,
                        )
                    }
                    Spacer(modifier = modifier.size(143.dp))
                    Button(
                        onClick = { winNum.intValue = 1},
                        colors = ButtonDefaults.buttonColors(
                            containerColor = SecondColor,
                            contentColor = Color.White
                        ),
                        shape = RoundedCornerShape(0),
                        modifier = modifier
                            .fillMaxWidth()
                            .align(Alignment.CenterHorizontally),
                    )

                    {
                        Text(
                            text = "Start",
                            fontSize = 24.sp,
                            modifier = modifier,
                        )
                    }
                }
            }




        }

        1-> {
            Box(
                modifier = with (Modifier) {
                    fillMaxSize()
                        .paint(
                            painterResource(id = R.drawable.backgroundfirst),
                            contentScale = ContentScale.FillBounds
                        )

                })
            {

                Box(modifier = modifier
                    .fillMaxSize()
                    .paint(
                        painterResource(id = R.drawable.kotec),
                        contentScale = ContentScale.FillBounds
                    )
                )
                {
                    Column {
                        Spacer(modifier = modifier.size(500.dp))

                        Box(
                            contentAlignment = Alignment.Center,
                            modifier = modifier
                                .fillMaxWidth()
                                .height(34.dp)
                                .background(color = SecondColor)

                        ){
                            Text(text = "Hello! My name is Jack. And you?", color = Color.White, fontSize = 24.sp)

                        }
                        Spacer(modifier = modifier.size(42.dp))

                        TextField(
                            value = name.value,
                            onValueChange = {name.value = it},
                            placeholder = {
                                Text(text = "Input your name...")
                            },
                            modifier = modifier.fillMaxWidth(),

                            )

                        Spacer(modifier = modifier.size(17.dp))

                        Button(
                            onClick = { winNum.intValue = 2},
                            colors = ButtonDefaults.buttonColors(
                                containerColor = SecondColor,
                                contentColor = Color.White
                            ),
                            shape = RoundedCornerShape(0),
                            modifier = modifier
                                .fillMaxWidth()
                                .align(Alignment.CenterHorizontally),
                        )

                        {
                            Text(
                                text = "Accept",
                                fontSize = 24.sp,
                                modifier = modifier,
                            )
                        }
                    }

                }
            }

        }

        2 -> {
            Box(
                modifier = with (Modifier) {
                    fillMaxSize()
                        .paint(
                            painterResource(id = R.drawable.backgroundfirst),
                            contentScale = ContentScale.FillBounds
                        )

                })
            {

                Box(modifier = modifier
                    .fillMaxSize()
                    .paint(
                        painterResource(id = R.drawable.kotec),
                        contentScale = ContentScale.FillBounds
                    )
                )
                {
                    Column {
                        Spacer(modifier = modifier.size(500.dp))

                        Box(
                            contentAlignment = Alignment.Center,
                            modifier = modifier
                                .fillMaxWidth()
                                .background(color = SecondColor)

                        ){
                            Text(text = "Great, ${name.value}! What we are going to do?", color = Color.White, fontSize = 24.sp)

                        }

                        Spacer(modifier = modifier.size(17.dp))

                        Button(
                            onClick = {},
                            colors = ButtonDefaults.buttonColors(
                                containerColor = MainColor,
                                contentColor = Color.White
                            ),
                            shape = RoundedCornerShape(0),
                            modifier = modifier
                                .fillMaxWidth()
                                .align(Alignment.CenterHorizontally),
                        )

                        {
                            Text(
                                text = "Walking",
                                fontSize = 24.sp,
                                modifier = modifier,
                            )
                        }

                        Spacer(modifier = modifier.size(17.dp))

                        Button(
                            onClick = {winNum.intValue = 3},
                            colors = ButtonDefaults.buttonColors(
                                containerColor = MainColor,
                                contentColor = Color.White
                            ),
                            shape = RoundedCornerShape(0),
                            modifier = modifier
                                .fillMaxWidth()
                                .align(Alignment.CenterHorizontally),
                        )

                        {
                            Text(
                                text = "Hiking",
                                fontSize = 24.sp,
                                modifier = modifier,
                            )
                        }

                        Spacer(modifier = modifier.size(17.dp))

                        Button(
                            onClick = {},
                            colors = ButtonDefaults.buttonColors(
                                containerColor = MainColor,
                                contentColor = Color.White
                            ),
                            shape = RoundedCornerShape(0),
                            modifier = modifier
                                .fillMaxWidth()
                                .align(Alignment.CenterHorizontally),
                        )

                        {
                            Text(
                                text = "Go to the field",
                                fontSize = 24.sp,
                                modifier = modifier,
                            )
                        }
                    }

                }
            }
        }

        3 -> {
            Box(
                modifier = with (Modifier) {
                    fillMaxSize()
                        .paint(
                            painterResource(id = R.drawable.lastbackground),
                            contentScale = ContentScale.FillBounds
                        )

                })
            {
                Column {
                    Spacer(modifier = modifier.size(500.dp))
                    Box(
                        contentAlignment = Alignment.Center,
                        modifier = modifier
                            .fillMaxWidth()
                            .background(color = SecondColor)

                    ){
                        Text(text = "How cozy... But it’s already getting dark...", color = Color.White, fontSize = 24.sp)

                    }
                    Spacer(modifier = modifier.size(17.dp))

                    Button(
                        onClick = {},
                        colors = ButtonDefaults.buttonColors(
                            containerColor = MainColor,
                            contentColor = Color.White
                        ),
                        shape = RoundedCornerShape(0),
                        modifier = modifier
                            .fillMaxWidth()
                            .align(Alignment.CenterHorizontally),
                    )

                    {
                        Text(
                            text = "Go home and watch the film",
                            fontSize = 24.sp,
                            modifier = modifier,
                        )
                    }

                    Spacer(modifier = modifier.size(17.dp))

                    Button(
                        onClick = {},
                        colors = ButtonDefaults.buttonColors(
                            containerColor = MainColor,
                            contentColor = Color.White
                        ),
                        shape = RoundedCornerShape(0),
                        modifier = modifier
                            .fillMaxWidth()
                            .align(Alignment.CenterHorizontally),
                    )

                    {
                        Text(
                            text = "Go home and celebrate Halloween",
                            fontSize = 24.sp,
                            modifier = modifier,
                        )
                    }
                }
            }
        }
    }


}

