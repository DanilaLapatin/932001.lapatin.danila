class Solution {
    fun plusOne(digits: IntArray): IntArray {
        var s: String =""
        for (digit in digits) {
            s+=digit.toString()
        }
        println(s)
        s = (s.toInt()+1).toString()
        println(s)
        var list  = ArrayList<Int>()
        for (strdg in s) {
            list.add(Character.digit(strdg,10))
        }
        return list.toIntArray()
    }
}

fun main() {
  val Sol = Solution()
  val arr:IntArray = intArrayOf(1,3,4,5)
  println(Sol.plusOne(arr).contentToString())
}