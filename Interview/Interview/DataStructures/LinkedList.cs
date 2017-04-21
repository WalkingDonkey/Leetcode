namespace Interview.DataStructures
{
    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class LinkedList
    {
        public ListNode ReverseListIterative(ListNode head)
        {
            ListNode p = head, q = null, t = null;
            while (p != null)
            {
                q = p.next;
                p.next = t;
                t = p;
                p = q;
            }

            return t;
        }

        public ListNode ReverseListIterativeWithDummyNode(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            var dummy = new ListNode(0);
            dummy.next = head;
            var start = head;
            var then = start.next;
            while (then != null)
            {
                start.next = then.next;
                then.next = dummy.next;
                dummy.next = then;
                then = start.next;
            }

            return dummy.next;
        }

        public ListNode ReverseListRecursive(ListNode head)
        {
            return ReverseListRecursiveCore(head);
        }

        private ListNode ReverseListRecursiveCore(ListNode head, ListNode pre = null)
        {
            if (head != null)
            {
                var temp = head.next;
                head.next = pre;
                return ReverseListRecursiveCore(temp, head);
            }
            else
            {
                return pre;
            }
        }

        public ListNode ReverseBetweenWithDummy(ListNode head, int m, int n)
        {
            if (head == null)
            {
                return null;
            }

            var dummy = new ListNode(0);
            dummy.next = head;
            var pre = dummy;
            var range = n - m;
            while (--m > 0)
            {
                pre = pre.next;
            }

            var start = pre.next;
            var then = start.next;
            while (range-- > 0)
            {
                start.next = then.next;
                then.next = pre.next;
                pre.next = then;
                then = start.next;
            }

            return dummy.next;
        }

        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            if (head == null)
            {
                return null;
            }

            ListNode first = head, second = head, pre = null;
            while (--m > 0)
            {
                pre = first;
                first = first.next;
            }

            while (--n > 0)
            {
                second = second.next;
            }

            var left = second.next;
            second.next = null;

            ListNode p = first, q, t = null;
            while (p != null)
            {
                q = p.next;
                p.next = t;
                t = p;
                p = q;
            }
            first.next = left;

            if (pre != null)
            {
                pre.next = t;
            }
            else
            {
                head = t;
            }

            return head;
        }

        public ListNode MergeTwoSortedLists(ListNode l1, ListNode l2)
        {
            var dummy = new ListNode(0);
            var merged = dummy;
            var h1 = l1;
            var h2 = l2;
            while (h1 != null && h2 != null)
            {
                if (h1.val < h2.val)
                {
                    merged.next = h1;
                    h1 = h1.next;
                }
                else
                {
                    merged.next = h2;
                    h2 = h2.next;
                }
                merged = merged.next;
            }

            while (h1 != null)
            {
                merged.next = h1;
                h1 = h1.next;
                merged = merged.next;
            }

            while (h2 != null)
            {
                merged.next = h2;
                h2 = h2.next;
                merged = merged.next;
            }

            //if (h1 != null)
            //{
            //    merged.next = h1;
            //}

            //if (h2 != null)
            //{
            //    merged.next = h2;
            //}

            return dummy.next;
        }
    }
}
