class Solution {
    fun removeElement(nums: IntArray, value: Int): Int {
        var count = 0
        var resnums: MutableList<Int>? = mutableListOf()
        for (num in nums) {
            if (num == value) {
                count+=1
            }
            else{
                resnums!!.add(num)
            }
        }
        println(resnums)
        return nums.size-count
    }
}

fun main() {
    val Sol = Solution()
    var arr: IntArray = intArrayOf(0,1,2,3,4,4,4,5,6,4,4,4,7,4,8,9)
    val Value = 3
    print(Sol.removeElement(arr,Value))
}