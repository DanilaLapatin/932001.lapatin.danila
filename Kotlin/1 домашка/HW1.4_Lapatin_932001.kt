class Solution {
    fun strStr(haystack: String, needle: String): Int {
        return haystack.indexOf(needle,0)
    }
}

fun main() {
  val Sol = Solution()
  val str = "son of Odin's son"
  val substr = "son"
  print("The first index of substring '$substr' in string '$str' is ${Sol.strStr(str,substr)}")
  
}