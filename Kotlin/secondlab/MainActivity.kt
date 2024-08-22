package com.example.secondlab

import android.graphics.Color
import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.Image
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
import androidx.compose.foundation.layout.width
import androidx.compose.material3.Button
import androidx.compose.material3.ButtonDefaults
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.layout.ContentScale
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.text.font.Font
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import com.example.secondlab.ui.theme.SecondLabTheme
import com.example.secondlab.ui.theme.Pink40
import com.example.secondlab.ui.theme.Purple40
import com.example.secondlab.ui.theme.PurpleGrey40
import com.example.secondlab.ui.theme.airBnbFont
import com.example.secondlab.ui.theme.blue1
import com.example.secondlab.ui.theme.robBold
import com.example.secondlab.ui.theme.robReg

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContent {
            SecondLabTheme {
                // A surface container using the 'background' color from the theme
                Surface(modifier = Modifier.fillMaxSize(), color = MaterialTheme.colorScheme.background) {
                    Greeting("Android")
                }
            }
        }
    }
}

@Composable
fun Greeting(name: String, modifier: Modifier = Modifier) {
    Box(
        modifier = Modifier.fillMaxSize(),
        contentAlignment = Alignment.Center
    ) {
        Image(
            painter = painterResource(id = R.drawable.frame),
            modifier = modifier.fillMaxSize(),
            contentDescription = "background image",
            alignment = Alignment.TopCenter,
            contentScale = ContentScale.FillWidth

        )

        Column(verticalArrangement = Arrangement.SpaceAround) {
            Box(modifier = Modifier.fillMaxWidth(), contentAlignment = Alignment.Center) {
                Row(Modifier, horizontalArrangement = Arrangement.Center) {
                    val image = painterResource(id = R.drawable.logo)
                    Text(
                        letterSpacing = 5.sp,
                        text = "Silent",
                        fontSize = 24.sp,
                        fontFamily = airBnbFont,
                        modifier = modifier.padding(end = 10.dp)

                    )
                    Image(
                        painter = image,
                        contentDescription = "logo",
                        modifier = modifier.size(30.dp)
                    )
                    Text(
                        letterSpacing = 5.sp,
                        text = "Moon",
                        fontSize = 24.sp,
                        fontFamily = airBnbFont,
                        modifier = modifier.padding(start = 10.dp)

                    )
                }
            }
            Spacer(modifier = Modifier.size(37.dp))
            Box(modifier = Modifier.fillMaxWidth(), contentAlignment = Alignment.Center) {
                Image(
                    painter = painterResource(id = R.drawable.group),
                    modifier = modifier
                        .width(290.dp)
                        .height(175.dp),
                    contentDescription = "background image",
                    alignment = Alignment.Center,
                    contentScale = ContentScale.FillWidth

                )
            }
            Spacer(modifier = Modifier.size(37.dp))
            Box(modifier = Modifier.fillMaxWidth(), contentAlignment = Alignment.Center) {
                Column(Modifier.fillMaxWidth().padding(32.dp), verticalArrangement = Arrangement.Center, horizontalAlignment = Alignment.CenterHorizontally) {
                    Text(
                        text = "We are what we do",
                        fontSize = 30.sp,
                        fontFamily = robBold,
                        textAlign = TextAlign.Center
                    )
                    Spacer(modifier = Modifier.size(10.dp))

                    Text(
                        text = "Thousand of people are using silent moon for smalls meditation ",
                        fontSize = 16.sp,
                        fontFamily = robReg,
                        color = PurpleGrey40,
                        textAlign = TextAlign.Center

                    )
                    Spacer(modifier = Modifier.size(100.dp))
                    Button(colors = ButtonDefaults.buttonColors(
                        containerColor = blue1
                    ), modifier = Modifier
                        .fillMaxWidth()
                        .height(75.dp),onClick = { /*TODO*/ }
                    ) {
                        Text(
                            text = "SIGN UP"
                        )
                    }
                    Spacer(modifier =  Modifier.size(19.dp))
                    Button(
                        modifier = Modifier
                            .fillMaxWidth()
                            .align(Alignment.CenterHorizontally),
                        onClick = {},
                        colors = ButtonDefaults.buttonColors(
                            containerColor = androidx.compose.ui.graphics.Color.Transparent
                        )

                    ) {
                        Text(
                            text = "ALREADY HAVE AN ACCOUNT? ",
                            color = PurpleGrey40,
                        )
                        Text(
                            text = "LOG IN",
                            color = blue1,

                            )
                    }
                }
            }
        }
    }
}

@Preview(showBackground = true)
@Composable
fun GreetingPreview() {
    SecondLabTheme {
        Greeting("Android")
    }
}