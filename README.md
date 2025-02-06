Here's a **README** file for your **Hill Cipher File Encryption Program**:  

---

## **Hill Cipher File Encryption**
This is a **C# WinForms application** that uses the **Hill Cipher algorithm** to encrypt and decrypt **any file type**.  
The program supports **direct file modification**, meaning encrypted files are overwritten in place.

---

## **🔹 Features**
✅ Encrypts and decrypts **all file types** (TXT, PDFs, images, EXE, etc.)  
✅ Uses **Hill Cipher (2x2 matrix encryption)**  
✅ **Directly modifies files** (no extra encrypted file is created)  
✅ Supports **binary encryption** for non-text files  
✅ Uses **OpenFileDialog** to select files easily  

---

## **🛠 How It Works**
### **1️⃣ Encryption Process**
1. Click the **"Encrypt File"** button.  
2. Select a file (e.g., `document.pdf`, `photo.jpg`).  
3. The file is **encrypted in place** using the **Hill Cipher algorithm**.  
4. The file becomes **unreadable** until decrypted.  

### **2️⃣ Decryption Process**
1. Click the **"Decrypt File"** button.  
2. Select the previously **encrypted file**.  
3. The file is **restored to its original state**.  

---

## **⚠ Important Notes**
- **Encrypted files are overwritten in place**, so make a **backup before encrypting important files**.  
- **Hill Cipher requires an even number of bytes**—if a file has an odd number of bytes, **padding is added**.  
- If a file is **accidentally encrypted**, simply run the **decryption process** to restore it.  

---

## **📜 How to Run the Program**
### **Requirements**
- Windows OS  
- .NET Framework  
- Visual Studio (for compiling the C# code)  

### **Steps to Run**
1. Clone or download the repository.  
2. Open the project in **Visual Studio**.  
3. Build and run the project.  
4. Use the **buttons in the WinForms UI** to encrypt/decrypt files.  

---

## **📌 Code Overview**
### **Main Functionalities**
- `EncryptBytes(byte[] data)`: Encrypts file data using **Hill Cipher matrix multiplication**.  
- `DecryptBytes(byte[] data)`: Decrypts file data using **Hill Cipher inverse matrix**.  
- `button1_Click_1(object sender, EventArgs e)`: Opens a file and **encrypts it in place**.  
- `button2_Click_1(object sender, EventArgs e)`: Opens a file and **decrypts it back**.  
- `ModInverse(int a, int m)`: Computes the **modular inverse** needed for decryption.  

---

## **🔧 Future Improvements**
🔹 **Allow users to input a custom encryption key matrix**.  
🔹 **Improve error handling** for unsupported files.  
🔹 **Add a backup system** before modifying files.  
🔹 **Support larger matrices (3x3, 4x4) for stronger encryption**.  

---

## **👨‍💻 Author**
Developed by **Mark Yuri P Geagonia**  

---

Let me know if you need modifications! 🚀
