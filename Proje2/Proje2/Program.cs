using System;
using System.Collections;
using System.Collections.Generic;

namespace Proje2
{
    class Müşteri
    {
        public string MüşteriAdı;
        public int ÜrünSayısı;
        
        public Müşteri(string ad, int say) 
        {
            this.MüşteriAdı= ad;
            this.ÜrünSayısı= say;
        }
        
        public string data()
        {
            return MüşteriAdı + " " + ÜrünSayısı;
        }
        
    }
    
    class Yığıt
    {
        private int maxSize; // size of stack array
        private Müşteri[] stackArray;
        private int top; // top of stack
                         //--------------------------------------------------------------
        public Yığıt(int size) // constructor
        {
            this.maxSize = size; // set array size
            this.stackArray = new Müşteri[maxSize]; // create array
            this.top = -1; // no items yet
        }
        public void push(Müşteri j) // put item on top of stack
        {
            stackArray[++top] = j; // increment top, insert item
        }

        public Müşteri pop() // take item from top of stack
        {
            return stackArray[top--]; // access item, decrement top
            
        }
        public Müşteri peek() // peek at top of stack
        {
            return stackArray[top];
        }
        public bool isEmpty() // true if stack is empty
        {
            return (top == -1);
        }
        public bool isFull() // true if stack is full
        {
            return (top == maxSize - 1);
        }

    
        public int getMaxSize()
        {
            return maxSize;
        }
    
    }

    class Kuyruk
    {
        private int maxSize;
        private Müşteri[] queArray;
        private int front;
        private int rear;
        public Kuyruk(int s) // constructor
        {
            maxSize = s + 1; // array is 1 cell larger
            queArray = new Müşteri[maxSize]; // than requested
            front = 0;
            rear = -1;
        }
        public void insert(Müşteri j) // put item at rear of queue
        {
            if (rear == maxSize - 1)
                rear = -1;
            queArray[++rear] = j;
        }
        public Müşteri sil() // take item from front of queue
        {
            Müşteri temp = queArray[front++];
            if (front == maxSize)
                front = 0;
            return temp;
        }
        public Müşteri peek() // peek at front of queue
        {
            return queArray[front];
        }
        public bool isEmpty() // true if queue is empty
        {
            return (rear + 1 == front || (front + maxSize - 1 == rear));
        }
        public bool isFull() // true if queue is full
        {
            return (rear + 2 == front || (front + maxSize - 2 == rear));
        }
        public int size() // (assumes queue not empty)
        {
            if (rear >= front) // contiguous sequence
                return rear - front + 1;
            else // broken sequence
                return (maxSize - front) + (rear + 1);
        }
        
    } 

    class ÖncelikliKuyruk
    {
        private List<Müşteri> queArr;
        
        public ÖncelikliKuyruk()
        {
            queArr = new List<Müşteri>();
           
        }

        public bool bosMu()//sıra boş ise doğru döndürücek
        {
            return (0==queArr.Count);
        }
        public void ekle(Müşteri müş)// sıranın sonuna ekler 
        {
            queArr.Add(müş);
        }
        public Müşteri sil()//eğer sıra boş ise adı 0 ürün saıyısı 0 olan nesne döndürecektir.
        {
            Müşteri müşteriDöndür= new Müşteri("0",0);
            if (!bosMu())//ancak sıra boş değilse çıkarma işlemi yapılabilir
            {

                int indexOfBiggest = 0;
                for (int i = 0; i < queArr.Count; i++) {
                    if (queArr[indexOfBiggest].ÜrünSayısı < queArr[i].ÜrünSayısı)//en çok ürün sayısına sahip nesnenin indexinin bulunması ve tutulması
                    {
                        indexOfBiggest = i;

                    }
                }
                müşteriDöndür = queArr[indexOfBiggest];
                queArr.RemoveAt(indexOfBiggest);
                
            }

            return müşteriDöndür;
        }

        public Müşteri artanSıradaSil()//eğer sıra boş ise adı 0 ürün saıyısı 0 olan nesne döndürecektir.
        {
            Müşteri müşteriDöndür = new Müşteri("0", 0);
            if (!bosMu())//ancak sıra boş değilse çıkarma işlemi yapılabilir
            {

                int indexOfSmaller = 0;
                for (int i = 0; i < queArr.Count; i++)
                {
                    if (queArr[indexOfSmaller].ÜrünSayısı > queArr[i].ÜrünSayısı)//en az ürün sayısına sahip nesnenin indexinin bulunması ve tutulması
                    {
                        indexOfSmaller = i;

                    }
                }
                müşteriDöndür = queArr[indexOfSmaller];
                queArr.RemoveAt(indexOfSmaller);

            }

            return müşteriDöndür;
        }

    }




  

    class Program
    {
        static ArrayList BileşikVeriYapısıOluşturmaVeElemanEklemeMetodu(string[] sList, int[] iList)
        {
            Random rand = new Random();//birden fazla random sayı üretilecekse nesne oluşturulması sayının tekrarlanma hatasını önlüyor
            int randNum = rand.Next(1, 6);
            
            ArrayList aList = new ArrayList();
            List<Müşteri> arr = new List<Müşteri>();


            for (int i = 0; i < sList.Length; i++)
            {
                Müşteri müşteri = new Müşteri(sList[i], iList[i]);
                arr.Add(müşteri);

                if ((arr.Count == randNum)||(i + 1 == sList.Length) )//liste yeteri kadar eleman sayısına ulaşmış veya giriş dizisinin son itemine ulaşılmış. artık liste arrayliste eklenebilir
                {
                    aList.Add(arr);
                    randNum = rand.Next(1, 6);
                    arr = new List<Müşteri>();//yeni bir liste oluşturulup referansı ileride arrayliste verilecek
                    
                }
                
            }
            
            return aList;
        }


        static void BileşikVeriYapısındakiElemanlarıYazdırınız(ArrayList aList)
        {
            foreach (List<Müşteri> müşlis in aList)
            {
                foreach (Müşteri müş in müşlis)
                {
                    Console.Write(müş.data() + " , ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(" ");
        }
        
        static void for2A(ArrayList aList,int say) {

            Yığıt müşteriler = new Yığıt(say);

            foreach (List<Müşteri> müşlis in aList)
            {
                foreach (Müşteri müş in müşlis)//arraylist içerisindeki nesnelere tek tek ulaşmak
                {
                    müşteriler.push(müş);//yığıta ekleme
                }
            }

            for (int i =0; i<müşteriler.getMaxSize();i++) {

                Console.WriteLine(müşteriler.pop().data());//yığıtın en üstündeki nesnelerin yığıttan çıkartılıp içeriğindeki bilgilerin yazdırılması
            }
            Console.WriteLine("------");
        }

        static void for2B(ArrayList aList, int say)
        {

            Kuyruk müşteriler = new Kuyruk(say);

            foreach (List<Müşteri> müşlis in aList)
            {
                foreach (Müşteri müş in müşlis)//arraylist içerisindeki nesnelere tek tek ulaşmak
                {
                    müşteriler.insert(müş);//sıraya ekleme
                }
            }

            for (int i = 0; i < say; i++)
            {

                Console.WriteLine(müşteriler.sil().data());//sıranın en sonundaki nesnelerin sıradan çıkartılıp içeriğindeki bilgilerin yazdırılması
            }
            Console.WriteLine("------");
        
        }

        static void for3A(ArrayList aList)
        {
            ÖncelikliKuyruk müşteriler = new ÖncelikliKuyruk();
            foreach (List<Müşteri> müşlis in aList)
            {
                foreach (Müşteri müş in müşlis)//arraylist içerisindeki nesnelere tek tek ulaşmak
                {
                    müşteriler.ekle(müş);//sıraya ekleme
                }
            }
            
            while (!müşteriler.bosMu()){
                Console.WriteLine(müşteriler.sil().data());
            }
            Console.WriteLine("------");
        }


        static void for4B(ArrayList aList, string[] MüşteriAdı) {
            Kuyruk müşteriler = new Kuyruk(MüşteriAdı.Length);
            ÖncelikliKuyruk öncelikliMüşterilerArtan = new ÖncelikliKuyruk();

            foreach (List<Müşteri> müşlis in aList)
            {
                foreach (Müşteri müş in müşlis)//arraylist içerisindeki nesnelere tek tek ulaşmak
                {
                    müşteriler.insert(müş);//sıraya ekleme
                    öncelikliMüşterilerArtan.ekle(müş);
                }
            }

            int öncelikliİşlemTamamlanmaSüresi = 0;
            int öncekiMüşteriTamamlamaSüresi = 0;
            Müşteri dönenMüşteri;
            while (!öncelikliMüşterilerArtan.bosMu())
            {
                dönenMüşteri = öncelikliMüşterilerArtan.artanSıradaSil();
                öncekiMüşteriTamamlamaSüresi+= dönenMüşteri.ÜrünSayısı;//her bir müşteri için toplam bekleme ve işlem süresi
                Console.WriteLine(dönenMüşteri.data()+" müşterisi için işlem bekleme süresi : "+öncekiMüşteriTamamlamaSüresi);
                öncelikliİşlemTamamlanmaSüresi += öncekiMüşteriTamamlamaSüresi;//bütün müşterilerin toplam bekleme süresi ve işlem süresi
            }
            Console.WriteLine("Önceli sıradaki müşterilerin ortalama bekleme süresi : " + (float)öncelikliİşlemTamamlanmaSüresi / (float)MüşteriAdı.Length);
            

            Console.WriteLine("-----");
            öncekiMüşteriTamamlamaSüresi = 0;
            int normalKuyrukTamamlanmaSüresi = 0;
            while (!müşteriler.isEmpty())
            {
                dönenMüşteri = müşteriler.sil();
                öncekiMüşteriTamamlamaSüresi+= dönenMüşteri.ÜrünSayısı;
                Console.WriteLine(dönenMüşteri.data() + " müşterisi için işlem bekleme süresi : " + öncekiMüşteriTamamlamaSüresi);
                normalKuyrukTamamlanmaSüresi += öncekiMüşteriTamamlamaSüresi;
            }
            Console.WriteLine("kuyruktaki müşterilerin ortalama bekleme süresi : " + (float)normalKuyrukTamamlanmaSüresi / (float)MüşteriAdı.Length);

        }


        static void Main(string[] args)
            {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            //1-)
            string[] MüşteriAdı = { "Ali", "Merve", "Veli", "Gülay", "Okan", "Zekiye", "Kemal", "Banu", "İlker", "Songül", "Nuri", "Deniz" };
            int[] ÜrünSayısı = { 8, 11, 16, 5, 15, 14, 19, 3, 18, 17, 13, 15 };

            //b-)
            ArrayList aList = BileşikVeriYapısıOluşturmaVeElemanEklemeMetodu(MüşteriAdı,ÜrünSayısı);
            BileşikVeriYapısındakiElemanlarıYazdırınız(aList);

            //c-)
            Console.WriteLine("ArrayList içerisindeki liste sayısı : "+aList.Count);
            Console.WriteLine("Listelerin ortalama elaman sayısı : " + (float)MüşteriAdı.Length/ (float)aList.Count);
            Console.WriteLine(" " );


            //2-)

            //a-) yığıt
            Console.WriteLine("2-a-)");
            for2A(aList,MüşteriAdı.Length);

            //b-)Kuyruk
            Console.WriteLine("2-b-)");
            for2B(aList,MüşteriAdı.Length);


            //3-)
            //a-)
            Console.WriteLine("3-a-)");
            for3A(aList);
            //b-)
            //bir dizi kullanılabilmesi için öncelikle sıraya alınabilecek maksimum insan sayısı belirlenmeli.
            //sıraya kaç kişi alınacağı belirtilmediği veya bilinmediği durumlarda dizi oluşturulamaz.

            //dizilerde aradan ya da baştan çıkartma işlemlerinden sonra 
            //dizide geri kalan itemlerin aradaki boşluğun kapatılması için indexlerinin 1 azaltılması gerekir dizideki eleman sayısı büyüdükçe bu işlem pahalılaşmaya başlar
            //list kullanımında remove methotları ile listeden çıkartılan itemler için index kaydırma işlemlerine gerek kalmamaktadır
            //

            //4-)
            //b-)
            for4B(aList,MüşteriAdı);
            
        }
    }
}
