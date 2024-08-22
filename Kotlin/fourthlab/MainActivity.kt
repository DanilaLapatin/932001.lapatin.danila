package com.example.fourthlab

import android.media.Image
import android.os.Bundle
import android.view.inputmethod.InputMethodInfo
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.Image
import androidx.compose.foundation.background
import androidx.compose.foundation.border
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
import androidx.compose.foundation.layout.width
import androidx.compose.foundation.lazy.LazyRow
import androidx.compose.foundation.lazy.items
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material3.Card
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.Shapes
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.material3.TextField
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.blur
import androidx.compose.ui.draw.paint
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.graphics.ImageBitmap
import androidx.compose.ui.layout.ContentScale
import androidx.compose.ui.layout.VerticalAlignmentLine
import androidx.compose.ui.modifier.modifierLocalConsumer
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.semantics.Role.Companion.Image
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import com.example.fourthlab.ui.theme.FourthLabTheme

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContent {
            FourthLabTheme {
                Surface(
                    modifier = Modifier.fillMaxSize(),
                    color = MaterialTheme.colorScheme.background
                ) {
                    Program()
                }
            }
        }
    }
}

@Composable
fun Program(modifier: Modifier = Modifier) {
    Box(modifier = modifier
        .fillMaxSize()
        .paint(painterResource(id = R.drawable.background), contentScale = ContentScale.FillBounds)
    ) {
        Column(
            modifier = modifier
                .padding(16.dp)
                .fillMaxWidth(),
            horizontalAlignment = Alignment.CenterHorizontally

        ) {
            Spacer(modifier = modifier.size(50.dp))
            Text(
                text = "Choose Movies",
                fontSize = 24.sp,
                modifier = modifier)
            Spacer(modifier = modifier.size(30.dp))
            Search();
            Spacer(modifier = modifier.fillMaxHeight(0.1f))
            Films();
        }

    }
}

@Composable
fun FilmCard(film: Film, modifier: Modifier = Modifier) {
    Box(
        modifier = modifier
            .height(100.dp).width(75.dp)
            .paint(painter = painterResource(id = film.imageId), contentScale = ContentScale.FillBounds)
    ) {

    }

}

@Composable
fun FilmList(films: List<Film>, modifier: Modifier = Modifier) {
    LazyRow(modifier = modifier.fillMaxSize()){
        items(films) {
                film -> FilmCard(film = film, modifier = modifier.padding(0.dp,0.dp, 8.dp, 0.dp))
        }
    }
}


@Composable
fun Films(modifier: Modifier = Modifier) {
    Column(
        modifier
            .fillMaxWidth()
            .fillMaxHeight(0.3f)) {
        Text(text = "Now Playing", fontSize = 24.sp)
        Spacer(modifier = modifier.size(16.dp))
        FilmList(films = DataSource().loadFirstFilms(), modifier = modifier)
        Spacer(modifier = modifier.size(16.dp))
    }

    Column(
        modifier
            .fillMaxWidth()
            .fillMaxHeight(0.45f)) {
        Text(text = "Now Playing", fontSize = 24.sp)
        Spacer(modifier = modifier.size(16.dp))
        FilmList(films = DataSource().loadSecondFilm(), modifier = modifier)
        Spacer(modifier = modifier.size(16.dp))
    }

    Column(
        modifier
            .fillMaxWidth()
            .fillMaxHeight(0.7f)) {
        Text(text = "Now Playing", fontSize = 24.sp)
        Spacer(modifier = modifier.size(16.dp))
        FilmList(films = DataSource().loadThirdFilms(), modifier = modifier)
    }
}

@Composable
fun Search(modifier: Modifier = Modifier) {
    Box(
        modifier = modifier
            .fillMaxWidth()
            .fillMaxHeight(0.05f)
            .border(1.dp, Color.White, shape = RoundedCornerShape(25))
    ) {
        Row(modifier.fillMaxSize(), horizontalArrangement = Arrangement.SpaceBetween, verticalAlignment = Alignment.CenterVertically) {
            Row(modifier.fillMaxHeight(), verticalAlignment = Alignment.CenterVertically) {
                Spacer(modifier = modifier.size(16.dp))
                Box(
                    modifier = modifier
                        .paint(
                            painterResource(id = R.drawable.magnifyingglass),
                            contentScale = ContentScale.FillBounds
                        )
                        .fillMaxHeight(0.5f)
                        .fillMaxWidth(0.050f),
                    contentAlignment = Alignment.Center
                ) {
                }

                Spacer(modifier = modifier.size(8.dp))
                Text(
                    text = "Search",
                )
            }
            Row(horizontalArrangement = Arrangement.SpaceBetween, verticalAlignment = Alignment.CenterVertically){
                Box(
                    modifier = modifier
                        .paint(
                            painterResource(id = R.drawable.microphone),
                            contentScale = ContentScale.FillBounds
                        )
                        .fillMaxHeight(0.5f)
                        .fillMaxWidth(0.050f),
                    contentAlignment = Alignment.Center
                ) {
                }

                Spacer(modifier = modifier.size(8.dp))
            }

        }
    }
}