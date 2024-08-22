
 class ListNode(var value: Int) {
    var NodeVal: Int = value 
    var next: ListNode? = null
 }
/*Рекурсивное сравнение и переопределение указателей */
class Solution {
    fun mergeTwoLists(list1: ListNode?, list2: ListNode?): ListNode? {
        /*Если узлы не null, сравниваем их*/
        if (list1 != null && list2 !=null) {
            /*Если значение на узле списка 1 меньше значения узле списка 2, перемещаем указатель с узла 1 списка на меньший из двух: следующего узла в списке 1 и узла в списке 2. После выхлда из функции возвращаем нынешний узел первого списка 1 */
            if (list1.NodeVal < list2.NodeVal) {
                list1.next = mergeTwoLists(list1.next, list2)
                return list1
            }
            /*Иначе перемещаем указатель с узла 2 списка на меньший из двух: следующего узла в списке 2 и узла в списке 1. После выхлда из функции возвращаем нынешний узел первого списка 2*/
            else {
                list2.next = mergeTwoLists(list1, list2.next)
                return list2
            }
        }
        /*Если один из узлов оказался null, то: */
        if ( list1 !=null ) {
            return list1
        }
        return list2
    }
    fun printList(list: ListNode?) {
    print("[")
    var l = list
    while(l != null) {
        print(l.NodeVal)
        l = l.next
    }
    print("]\n")
}
}


fun main() {
    val Sol = Solution()
    val List1Head = ListNode(1)
    val List2Head = ListNode(1)
    var l1 = if (List1Head != null) List1Head else ListNode(1)
    var l2 = if (List2Head != null) List2Head else ListNode(1)

    for (i in 1..3) {
        l1.next = ListNode(1+i)
        l2.next = ListNode(1+i*2)
        l1 = l1.next!!
        l2 = l2.next!!
    }
    l1.next = ListNode(5)

    Sol.printList(List1Head)
    Sol.printList(List2Head)

    val Result = Sol.mergeTwoLists(List1Head, List2Head)

    Sol.printList(Result)

}

