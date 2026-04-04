using System;
using System.Collections.Generic;

public class Solution {
    public bool IsValidSudoku(char[][] board) {
        // Use hash sets to track seen numbers in rows, columns, and boxes
        HashSet<string> seen = new HashSet<string>();

        for (int i = 0; i < 9; i++) {
            for (int j = 0; j < 9; j++) {
                char current = board[i][j];
                if (current != '.') {
                    string row = $"row{i}-{current}";
                    string col = $"col{j}-{current}";
                    string box = $"box{i/3}{j/3}-{current}";

                    if (!seen.Add(row) || !seen.Add(col) || !seen.Add(box))
                        return false;
                }
            }
        }

        return true;
    }
}
