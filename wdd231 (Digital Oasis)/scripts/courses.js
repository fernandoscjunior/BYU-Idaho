const courses = [
    {
        subject: 'CSE',
        number: 110,
        title: 'Introduction to Programming',
        credits: 2,
        certificate: 'Web and Computer Programming',
        description: 'This course will introduce students to programming. It will introduce the building blocks of programming languages (variables, decisions, calculations, loops, array, and input/output) and use them to solve problems.',
        technology: [
            'Python'
        ],
        completed: true
    },
    {
        subject: 'WDD',
        number: 130,
        title: 'Web Fundamentals',
        credits: 2,
        certificate: 'Web and Computer Programming',
        description: 'This course introduces students to the World Wide Web and to careers in web site design and development. The course is hands on with students actually participating in simple web designs and programming. It is anticipated that students who complete this course will understand the fields of web design and development and will have a good idea if they want to pursue this degree as a major.',
        technology: [
            'HTML',
            'CSS'
        ],
        completed: true
    },
    {
        subject: 'CSE',
        number: 111,
        title: 'Programming with Functions',
        credits: 2,
        certificate: 'Web and Computer Programming',
        description: 'CSE 111 students become more organized, efficient, and powerful computer programmers by learning to research and call functions written by others; to write, call , debug, and test their own functions; and to handle errors within functions. CSE 111 students write programs with functions to solve problems in many disciplines, including business, physical science, human performance, and humanities.',
        technology: [
            'Python'
        ],
        completed: true
    },
    {
        subject: 'CSE',
        number: 210,
        title: 'Programming with Classes',
        credits: 2,
        certificate: 'Web and Computer Programming',
        description: 'This course will introduce the notion of classes and objects. It will present encapsulation at a conceptual level. It will also work with inheritance and polymorphism.',
        technology: [
            'C#'
        ],
        completed: true
    },
    {
        subject: 'WDD',
        number: 131,
        title: 'Dynamic Web Fundamentals',
        credits: 2,
        certificate: 'Web and Computer Programming',
        description: 'This course builds on prior experience in Web Fundamentals and programming. Students will learn to create dynamic websites that use JavaScript to respond to events, update content, and create responsive user experiences.',
        technology: [
            'HTML',
            'CSS',
            'JavaScript'
        ],
        completed: true
    },
    {
        subject: 'WDD',
        number: 231,
        title: 'Frontend Web Development I',
        credits: 2,
        certificate: 'Web and Computer Programming',
        description: 'This course builds on prior experience with Dynamic Web Fundamentals and programming. Students will focus on user experience, accessibility, compliance, performance optimization, and basic API usage.',
        technology: [
            'HTML',
            'CSS',
            'JavaScript'
        ],
        completed: false
    }
]

//Filters courses
const creditsText = document.querySelector('#credits');

function createCards(filteredCourses) {
    cleanScreen();
    let finalCredit = 0;
    const container = document.getElementById("card-container");

    filteredCourses.forEach(item => {
        
        const card = document.createElement("div");
        card.className = "card";
        const title = document.createElement("h4");
        if (item.completed == true){
            title.textContent = "✔️" + item.subject + "" + item.number;
            card.style.backgroundColor = 'antiquewhite';
        }
        else {
            title.textContent = item.subject + "" + item.number;
        }
        finalCredit += item.credits;

        //event to check click to open modal
        card.addEventListener('click', () => {
            displayCourseDetails(item);
        });

        card.appendChild(title);
        container.appendChild(card);
        creditsText.innerHTML = "Course Credits: " + finalCredit;
    });
}


createCards(courses);

const all = document.querySelector("#all");
const cse = document.querySelector("#cse");
const wdd = document.querySelector("#wdd");

all.addEventListener("click", () =>{
    createCards(courses)
});

cse.addEventListener("click", () => {
    createCards(courses.filter(course => course.subject == "CSE"));
});

wdd.addEventListener("click", () => {
    createCards(courses.filter(course => course.subject == "WDD"));
});

//cleans screen before showing filtered results
function cleanScreen() {
    const main = document.getElementById('card-container'); 
    main.innerHTML = '';
}

//Adding modal/dialog to courses

const courseDetails = document.querySelector('#course-details');

function displayCourseDetails(item) {
    courseDetails.innerHTML = null;
    courseDetails.innerHTML = `
    <h2>${item.subject} ${item.number}</h2>
    <h3>${item.title}</h3>
    <p><strong>Credits</strong>: ${item.credits}</p>
    <p><strong>Certificate</strong>: ${item.certificate}</p>
    <p>${item.description}</p>
    <p><strong>Technologies</strong>: ${item.technology.join(', ')}</p>
    <button id="closeModal">❌</button>
    `;
    courseDetails.showModal();
  
    closeModal.addEventListener("click", () => {
        courseDetails.close();
    });
}