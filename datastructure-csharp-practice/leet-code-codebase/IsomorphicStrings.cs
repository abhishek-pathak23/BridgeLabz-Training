public class Solution {
    public bool IsIsomorphic(string s, string t) {
        if (s.Length != t.Length)
            return false;

        int[] sMap = new int[256];
        int[] tMap = new int[256];

        for (int i = 0; i < s.Length; i++) {
            char a = s[i];
            char b = t[i];
            if (sMap[a] == 0 && tMap[b] == 0) {
                sMap[a] = b;
                tMap[b] = a;
            }

            else {
                if (sMap[a] != b || tMap[b] != a)
                    return false;
            }
        }
        return true;
    }
}
