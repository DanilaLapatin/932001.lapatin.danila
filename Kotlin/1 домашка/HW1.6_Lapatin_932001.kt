class Solution {
    fun lengthOfLastWord(s: String): Int {
        
        if( s.contains(' ')){
            var n = s.lastIndexOf(' ')
            var h: Int
            if (n == s.length-1){
                while(s[n] ==' '){
                    n -=1
                }
                h = n
            }
            else h = s.length-1
            var count = 0 
            while (s[h] !=' ') {
                h-=1
                count+=1
            }
            return count
        }
        else return s.length
    }
}

fun main() {
    val Sol = Solution()
    val s ="For The Emperor and Mankind"
    println("The last word's' length is ${Sol.lengthOfLastWord(s)}")
}