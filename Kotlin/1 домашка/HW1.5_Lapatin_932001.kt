class Solution {
    
    fun searchInsert(nums: IntArray, target: Int): Int {
        var start = 0
        var end = nums.size-1
        var mid: Int
        when {
            target>nums[end] ->return end+1
            target<=nums[start] ->return start
        } 
        while (start < end) {
            mid = start + (end - start) / 2
            when {
                target == nums[mid] -> return mid
                target < nums[mid] -> end = mid
                target > nums[mid] -> start = mid + 1
            }
        }
        return end
    }
}

fun main() {
    val Sol = Solution()
    val arr =intArrayOf(0,1,2,3,4,6,8,12,14,16,18,20)
    val  trg = 15
    println("Array: ${arr.joinToString()}, target is $trg")
    println("index of target in array is ${Sol.searchInsert(arr,trg)}")
    
}