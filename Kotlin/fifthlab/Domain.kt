package com.example.fifthlab

class Domain {
    fun validate(value: String): String {
        var res = "+7";
        if (!value.contains(regex = Regex("^\\d{10}\$"))) return "false"

        res += '(';
        res += value.subSequence(0, 3);
        res += ')';
        res += value.subSequence(3, value.length);

        return res;
    }
}