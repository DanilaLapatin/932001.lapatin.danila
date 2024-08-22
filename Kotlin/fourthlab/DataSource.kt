package com.example.fourthlab

class DataSource {
    fun loadFirstFilms() : List<Film> {
        return listOf(
            Film(R.drawable.image1),
            Film(R.drawable.image2),
            Film(R.drawable.image3),
            Film(R.drawable.image1),
            Film(R.drawable.image2),
            Film(R.drawable.image1),
            Film(R.drawable.image2),
            Film(R.drawable.image3),
            Film(R.drawable.image1),
            Film(R.drawable.image2),
        )
    }

    fun loadSecondFilm() : List<Film> {
        return listOf(
            Film(R.drawable.image5),
            Film(R.drawable.image6),
            Film(R.drawable.image7),
            Film(R.drawable.image5),
            Film(R.drawable.image6),
            Film(R.drawable.image5),
            Film(R.drawable.image6),
            Film(R.drawable.image7),
            Film(R.drawable.image5),
            Film(R.drawable.image6),
        )
    }

    fun loadThirdFilms() : List<Film> {
        return listOf(
            Film(R.drawable.image9),
            Film(R.drawable.image10),
            Film(R.drawable.image11),
            Film(R.drawable.image9),
            Film(R.drawable.image10),
            Film(R.drawable.image9),
            Film(R.drawable.image10),
            Film(R.drawable.image11),
            Film(R.drawable.image9),
            Film(R.drawable.image10)
        )
    }
}