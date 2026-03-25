from enum import Enum

# Represents the type of exam
class ExamType(Enum):
    SESSIONAL = 0
    MID = 1
    FINAL = 2

# Represents the status of the student on exam
class ExamStatus(Enum):
    FAIL = 0
    PASS = 1
