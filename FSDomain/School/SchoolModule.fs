module SchoolModule

open CourseModule

type SchoolName = string

type School = {
    name: SchoolName
    courses: Course list
}

let createSchool (name : string) : School = { name = name; courses = [] }

let isValidSchool (school: School) : bool = List.forall isValidCourse school.courses
