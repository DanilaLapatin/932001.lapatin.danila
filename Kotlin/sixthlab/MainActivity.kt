package com.example.sixthlab

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.Surface
import androidx.compose.ui.Modifier
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import androidx.navigation.compose.rememberNavController
import com.example.sixthlab.ui.theme.SixthLabTheme

enum class Screens {
    MAIN_SCREEN,
    DETAILS_SCREEN,
    CREATION_SCREEN,
    EDITION_SCREEN
}

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContent {
            val navController = rememberNavController()
            val viewModel = TaskViewModel(navController);

            SixthLabTheme {
                Surface(
                    modifier = Modifier.fillMaxSize(),
                    color = MaterialTheme.colorScheme.background
                ) {
                    NavHost(navController = navController, startDestination = Screens.MAIN_SCREEN.name) {
                        composable(Screens.MAIN_SCREEN.name) {
                            ScreenMain(viewModel) {
                                viewModel.createTask()
                            }
                        }
                        composable(Screens.DETAILS_SCREEN.name) {
                            ScreenDetails(viewModel);
                        }
                        composable(Screens.CREATION_SCREEN.name) {
                            ScreenCreation(viewModel)
                        }
                        composable(Screens.EDITION_SCREEN.name) {
                            ScreenEdition(viewModel);
                        }
                    }
                }
            }
        }
    }

}

