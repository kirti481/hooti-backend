// C# program to detect loop in a linked list 
using System; 
using System.Collections.Generic; 

class LinkedList { 

	// head of list 
	public Node head; 

	/* Linked list Node*/
	public class Node { 
		public int data; 
		public Node next; 
		public Node(int d) 
		{ 
			data = d; 
			next = null; 
		} 
	} 

	/* Inserts a new Node at front of the list. */
	public void push(int new_data) 
	{ 
		/* 1 & 2: Allocate the Node & 
				Put in the data*/
		Node new_node = new Node(new_data); 

		/* 3. Make next of new Node as head */
		new_node.next = head; 

		/* 4. Move the head to point to new Node */
		head = new_node; 
	} 

	// Returns true if there is a loop in linked 
	// list else returns false. 
	public static bool detectLoop(Node h) 
	{ 
		HashSet<Node> s = new HashSet<Node>(); 
		while (h != null) { 
			// If we have already has this node 
			// in hashmap it means their is a cycle 
			// (Because you we encountering the 
			// node second time). 
			if (s.Contains(h)) 
				return true; 

			// If we are seeing the node for 
			// the first time, insert it in hash 
			s.Add(h); 

			h = h.next; 
		} 

		return false; 
	} 

	/* Driver code*/
	public static void Main(String[] args) 
	{ 
		LinkedList llist = new LinkedList(); 

		llist.push(20); 
		llist.push(4); 
		llist.push(15); 
		llist.push(10); 

		/*Create loop for testing */
		llist.head.next.next.next.next = llist.head; 

		if (detectLoop(llist.head)) 
			Console.WriteLine("Loop found"); 
		else
			Console.WriteLine("No Loop"); 
	} 
} 
