using System;
using System.IO;

class StudentData
{
    static void Main()
    {
        using (BinaryWriter bw = new BinaryWriter(File.Open("student.dat", FileMode.Create)))
        {
            bw.Write(101);
            bw.Write("Rahul");
            bw.Write(8.7);
        }

        using (BinaryReader br = new BinaryReader(File.Open("student.dat", FileMode.Open)))
        {
            Console.WriteLine(br.ReadInt32());
            Console.WriteLine(br.ReadString());
            Console.WriteLine(br.ReadDouble());
        }
    }
}
