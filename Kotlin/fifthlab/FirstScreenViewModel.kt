package com.example.fifthlab

import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.setValue
import androidx.lifecycle.ViewModel

class FirstScreenViewModel : ViewModel() {
    var uiState by mutableStateOf<FirstScreenState>(FirstScreenState.Loading)
        private set

    private val domain = Domain();

    fun enterPhoneNumber(value: String) {
        uiState = FirstScreenState.Loading;
        val res = domain.validate(value);
        uiState = if (res == "false") FirstScreenState.Error("Error, please check the entered number")
        else FirstScreenState.Success(res);
    }
}

sealed class FirstScreenState {
    data object Loading: FirstScreenState();
    data class Success(val value:String) : FirstScreenState();
    data class Error(val error: String) : FirstScreenState();
}