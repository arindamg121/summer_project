import csv
import datetime
import os
import time
import tkinter as tk
from tkinter import messagebox

import cv2
import numpy as np
import pandas as pd
from PIL import Image

window = tk.Tk()

window.title("Attendance Management System")

window.configure(background="#FF9A8C")

window.grid_rowconfigure(0, weight=1)
window.grid_columnconfigure(0, weight=1)

x_cord = 75
y_cord = 20
checker = 0

message = tk.Label(
    window,
    text="Vivekanand Education Society's Institute Of Technology",
    bg="#FF9A8C",
    fg="black",
    width=45,
    height=1,
    font=("Times New Roman", 35, "bold underline"),
)
message.place(x=200, y=20)

message = tk.Label(
    window,
    text="Attendance Portal",
    bg="#FF9A8C",
    fg="black",
    width=40,
    height=1,
    font=("Times New Roman", 35, "bold underline"),
)
message.place(x=200, y=80)

lbl = tk.Label(
    window,
    text="Enter Your Roll No",
    width=20,
    height=2,
    fg="black",
    bg="#FF9A8C",
    font=("Times New Roman", 25, "bold"),
)
lbl.place(x=200 - x_cord, y=200 - y_cord)

txt = tk.Entry(
    window,
    width=30,
    bg="white",
    fg="blue",
    font=("Times New Roman", 15, "bold"),
)
txt.place(x=250 - x_cord, y=300 - y_cord)

lbl2 = tk.Label(
    window,
    text="Enter Your Name",
    width=20,
    fg="black",
    bg="#FF9A8C",
    height=2,
    font=("Times New Roman", 25, "bold"),
)
lbl2.place(x=600 - x_cord, y=200 - y_cord)

txt2 = tk.Entry(
    window,
    width=30,
    bg="white",
    fg="blue",
    font=("Times New Roman", 15, "bold"),
)
txt2.place(x=650 - x_cord, y=300 - y_cord)

lbl3 = tk.Label(
    window,
    text="Enter Your Shift",
    width=20,
    fg="black",
    bg="#FF9A8C",
    height=2,
    font=("Times New Roman", 25, "bold"),
)
lbl3.place(x=1005 - x_cord, y=200 - y_cord)

txt3 = tk.Entry(
    window,
    width=30,
    bg="white",
    fg="blue",
    font=("Times New Roman", 15, "bold"),
)
txt3.place(x=1065 - x_cord, y=300 - y_cord)

lbl4 = tk.Label(
    window,
    text="Notification",
    fg="black",
    bg="#FF9A8C",
    width=20,
    height=2,
    font=("Times New Roman", 25, "bold"),
)
lbl4.place(x=200 - x_cord, y=485 - y_cord)

message = tk.Label(
    window,
    text="",
    bg="white",
    fg="blue",
    width=66,
    height=2,
    activebackground="white",
    font=("Times New Roman", 15, "bold"),
)
message.place(x=645 - x_cord, y=500 - y_cord)

lbl5 = tk.Label(
    window,
    text="Attendance",
    fg="white",
    bg="lightgreen",
    width=20,
    height=2,
    font=("Times New Roman", 30, "bold"),
)
lbl5.place(x=120, y=570 - y_cord)

message2 = tk.Label(
    window,
    text="",
    fg="red",
    bg="yellow",
    activeforeground="green",
    width=60,
    height=4,
    font=("times", 15, "bold"),
)
message2.place(x=700, y=570 - y_cord)

lbl6 = tk.Label(
    window,
    text="Step 1",
    width=20,
    fg="green",
    bg="#FF9A8C",
    height=2,
    font=("Times New Roman", 20, "bold"),
)
lbl6.place(x=240 - x_cord, y=375 - y_cord)

lbl7 = tk.Label(
    window,
    text="Step 2",
    width=20,
    fg="green",
    bg="#FF9A8C",
    height=2,
    font=("Times New Roman", 20, "bold"),
)
lbl7.place(x=645 - x_cord, y=375 - y_cord)

lbl8 = tk.Label(
    window,
    text="Step 3",
    width=20,
    fg="green",
    bg="#FF9A8C",
    height=2,
    font=("Times New Roman", 20, "bold"),
)
lbl8.place(x=1100 - x_cord, y=375 - y_cord)


def clear1():
    txt.delete(0, "end")
    res = ""
    message.configure(text=res)


def clear2():
    txt2.delete(0, "end")
    res = ""
    message.configure(text=res)


def clear3():
    txt3.delete(0, "end")
    res = ""
    message.configure(text=res)


def is_number(s):
    try:
        float(s)
        return True
    except ValueError:
        pass

    try:
        import unicodedata

        unicodedata.numeric(s)
        return True
    except (TypeError, ValueError):
        pass

    return False


def TakeImages():
    roll_no = txt.get()
    name = txt2.get()
    shift = txt3.get()
    if not roll_no:
        res = "Please Enter Roll No"
        message.configure(text=res)
        MsgBox = tk.messagebox.askquestion(
            "Warning",
            "Please enter roll number properly , press yes if you understood",
            icon="warning",
        )
        if MsgBox == "no":
            tk.messagebox.showinfo(
                "Your need", "Please go through the readme file properly"
            )
    elif not name:
        res = "Please Enter Name"
        message.configure(text=res)
        MsgBox = tk.messagebox.askquestion(
            "Warning",
            "Please enter your name properly , press yes if you understood",
            icon="warning",
        )
        if MsgBox == "no":
            tk.messagebox.showinfo(
                "Your need", "Please go through the readme file properly"
            )
    elif not shift:
        res = "Please Enter Shift"
        message.configure(text=res)
        MsgBox = tk.messagebox.askquestion(
            "Warning",
            "Please enter your shift properly , press yes if you understood",
            icon="warning",
        )
        if MsgBox == "no":
            tk.messagebox.showinfo(
                "Your need", "Please go through the readme file properly"
            )

    elif (is_number(roll_no), name.isalpha() and shift.isalpha()):
        cam = cv2.VideoCapture(0)
        harcascadePath = "haarcascade_frontalface_default.xml"
        detector = cv2.CascadeClassifier(harcascadePath)
        sampleNum = 0
        while True:
            ret, img = cam.read()
            gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
            faces = detector.detectMultiScale(gray, 1.3, 5)
            for (x, y, w, h) in faces:
                cv2.rectangle(img, (x, y), (x + w, y + h), (255, 0, 0), 2)
                # incrementing sample number
                sampleNum = sampleNum + 1
                # saving the captured face in the dataset folder TrainingImage
                cv2.imwrite(
                    "TrainingImage\ "
                    + name
                    + "."
                    + roll_no
                    + "."
                    + str(sampleNum)
                    + ".jpg",
                    gray[y : y + h, x : x + w],
                )
                # display the frame
                cv2.imshow("frame", img)
            # wait for 100 miliseconds
            if cv2.waitKey(100) & 0xFF == ord("q"):
                break
            # break if the sample number is morethan 100
            elif sampleNum > 60:
                break
        cam.release()
        cv2.destroyAllWindows()
        res = (
            "Images Saved for Roll No : "
            + roll_no
            + " Name : "
            + name
            + " Shift : "
            + shift
        )
        row = [roll_no, name, shift]
        with open("StudentDetails\StudentDetails.csv", "a+") as csvFile:
            writer = csv.writer(csvFile)
            writer.writerow(row)
        csvFile.close()
        message.configure(text=res)
    else:
        if is_number(roll_no):
            res = "Enter Alphabetical Name"
            message.configure(text=res)
        if name.isalpha():
            res = "Enter Numeric Roll No"
            message.configure(text=res)
        if shift.isalpha():
            res = "Enter Alphabetical Shift"
            message.configure(text=res)


def TrainImages():
    recognizer = cv2.face_LBPHFaceRecognizer.create()
    faces, roll_no = getImagesAndLabels("TrainingImage")
    recognizer.train(faces, np.array(roll_no))
    recognizer.save("TrainingImageLabel\Trainner.yml")
    res = "Image Trained"
    clear1()
    clear2()
    clear3()
    message.configure(text=res)
    tk.messagebox.showinfo(
        "Completed", "Your model has been trained successfully!!"
    )


def getImagesAndLabels(path):

    imagePaths = [os.path.join(path, f) for f in os.listdir(path)]

    faces = []

    Ids = []

    for imagePath in imagePaths:
        # loading the image and converting it to gray scale
        pilImage = Image.open(imagePath).convert("L")
        # Now we are converting the PIL image into numpy array
        imageNp = np.array(pilImage, "uint8")
        # getting the roll no from the image
        roll_no = int(os.path.split(imagePath)[-1].split(".")[1])
        # extract the face from the training image sample
        faces.append(imageNp)
        Ids.append(roll_no)
    return faces, Ids


def TrackImages():
    recognizer = (
        cv2.face.LBPHFaceRecognizer_create()
    )  # cv2.createLBPHFaceRecognizer()
    recognizer.read("TrainingImageLabel\Trainner.yml")
    harcascadePath = "haarcascade_frontalface_default.xml"
    faceCascade = cv2.CascadeClassifier(harcascadePath)
    df = pd.read_csv("StudentDetails\StudentDetails.csv")
    cam = cv2.VideoCapture(0)
    font = cv2.FONT_HERSHEY_SIMPLEX
    col_names = ["Roll No", "Name", "Shift", "Date", "Time"]
    attendance = pd.DataFrame(columns=col_names)
    while True:
        _, im = cam.read()
        gray = cv2.cvtColor(im, cv2.COLOR_BGR2GRAY)
        faces = faceCascade.detectMultiScale(gray, 1.2, 5)
        for (x, y, w, h) in faces:
            cv2.rectangle(im, (x, y), (x + w, y + h), (225, 0, 0), 2)
            roll_no, conf = recognizer.predict(gray[y : y + h, x : x + w])
            if conf < 50:
                ts = time.time()
                date = datetime.datetime.fromtimestamp(ts).strftime("%Y-%m-%d")
                timeStamp = datetime.datetime.fromtimestamp(ts).strftime(
                    "%H:%M:%S"
                )
                first_ = lambda x: x[0]

                aa = first_(df.loc[df["Roll No"] == roll_no]["Name"].values)

                ss = first_(df["Shift"].values)
                tt = str(roll_no) + "-" + aa
                attendance.loc[len(attendance)] = [
                    roll_no,
                    aa,
                    ss,
                    date,
                    timeStamp,
                ]

            else:
                roll_no = "Unknown"
                tt = str(roll_no)
            if conf > 75:
                noOfFile = len(os.listdir("ImagesUnknown")) + 1
                cv2.imwrite(
                    "ImagesUnknown\Image" + str(noOfFile) + ".jpg",
                    im[y : y + h, x : x + w],
                )
            cv2.putText(im, str(tt), (x, y + h), font, 1, (255, 255, 255), 2)
        attendance = attendance.drop_duplicates(
            subset=["Roll No"], keep="first"
        )
        cv2.imshow("im", im)
        if cv2.waitKey(1) == ord("q"):
            break
    ts = time.time()
    date = datetime.datetime.fromtimestamp(ts).strftime("%Y-%m-%d")
    fileName = "Attendance\Attendance_" + date + ".csv"
    attendance.to_csv(fileName, index=False)
    cam.release()
    cv2.destroyAllWindows()
    res = attendance
    message2.configure(text=res)
    res = "Attendance Taken"
    message.configure(text=res)
    tk.messagebox.showinfo(
        "Completed",
        "Congratulations ! Your attendance has been marked successfully for the day!!",
    )


def send_mail():
    MsgBox = tk.messagebox.askquestion(
        "Send Mail", "Do you want to send mail", icon="warning"
    )
    if MsgBox == "yes":
        tk.messagebox.showinfo("Send Mail", "Mail has been sent")
        os.system("python3 automail.py")


def quit_window():
    MsgBox = tk.messagebox.askquestion(
        "Exit Application",
        "Are you sure you want to exit the application",
        icon="warning",
    )
    if MsgBox == "yes":
        tk.messagebox.showinfo(
            "Greetings",
            "Thank You very much for using our software. Have a nice day ahead!!",
        )
        window.destroy()


takeImg = tk.Button(
    window,
    text="Image Capture Button",
    command=TakeImages,
    fg="white",
    bg="blue",
    width=25,
    height=2,
    activebackground="#FF9A8C",
    font=("Times New Roman", 15, "bold"),
)
takeImg.place(x=245 - x_cord, y=425 - y_cord)
trainImg = tk.Button(
    window,
    text="Model Training Button",
    command=TrainImages,
    fg="white",
    bg="blue",
    width=25,
    height=2,
    activebackground="#FF9A8C",
    font=("Times New Roman", 15, "bold"),
)
trainImg.place(x=645 - x_cord, y=425 - y_cord)
trackImg = tk.Button(
    window,
    text="Attendance Marking Button",
    command=TrackImages,
    fg="white",
    bg="red",
    width=30,
    height=2,
    activebackground="#FF9A8C",
    font=("Times New Roman", 15, "bold"),
)
trackImg.place(x=1075 - x_cord, y=425 - y_cord)
send_mail = tk.Button(
    window,
    text="Send Mail",
    command=send_mail,
    fg="white",
    bg="blue",
    width=10,
    height=2,
    activebackground="#FF9A8C",
    font=("Times New Roman", 15, "bold"),
)
send_mail.place(x=600, y=735 - y_cord)
quitWindow = tk.Button(
    window,
    text="Quit",
    command=quit_window,
    fg="white",
    bg="red",
    width=10,
    height=2,
    activebackground="#FF9A8C",
    font=("Times New Roman", 15, "bold"),
)
quitWindow.place(x=800, y=735 - y_cord)

window.mainloop()
