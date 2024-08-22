class Solution {
    fun isValid(s: String): Boolean {
        
        if (s == "") {
            return true
        }
        else {
            val news = s.replace("{}","").replace("[]","").replace("()","") 
            if (news == s) {
                return false
            }
           return(isValid(news))
        }
    }
}

fun main() {
    val Sol = Solution()
    val TestInput1 = "()[]{}"
    val TestInput2 = "{{}[({}[](){}){}[]]()}"
    val TestInput3 = "{{}[({}[](){}){}[]]()}[](][}])"
 

    println(Sol.isValid(TestInput1))
    println(Sol.isValid(TestInput2))
    println(Sol.isValid(TestInput3))
    
}