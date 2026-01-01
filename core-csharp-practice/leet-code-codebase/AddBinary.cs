public class Solution {
    public string AddBinary(string a, string b) {
        int i = a.Length - 1, j = b.Length - 1, carry = 0;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        while (i >= 0 || j >= 0 || carry > 0) {
            int sum = carry;

            if (i >= 0) sum += a[i--] - '0';
            if (j >= 0) sum += b[j--] - '0';

            sb.Insert(0, (char)((sum % 2) + '0'));
            carry = sum / 2;
        }

        return sb.ToString();
    }
}
