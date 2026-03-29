from api.schemas.student_exam_logs import StudentExamLogsCreateDTO
from api.schemas.subject import SubjectCreateDTO
from api.schemas.student import StudentCreateDTO
from misc.enums import ExamType, ExamStatus
from api.schemas.exam import ExamCreateDTO
from api.schemas.user import UserCreateDTO
from generators.values import subject
from faker import Faker
from uuid import UUID
import random as rd

fk = Faker()

class Generator:
    @staticmethod
    def user(profile_pic = None) -> UserCreateDTO:
        return UserCreateDTO(
            profilePic=profile_pic,
            username=fk.user_name(),
            email=fk.email(domain='gmail.com'),
            password='12345678'
        )

    @staticmethod
    def student(user_id: UUID | str) -> StudentCreateDTO:
        return StudentCreateDTO(
            creatorUserId=user_id,
            studentName=fk.first_name(),
            rollNumber=fk.random_number(digits=4, fix_len=True),
            dateOfBirth=fk.date_of_birth(minimum_age=18, maximum_age=26)
        )

    @staticmethod
    def subject(user_id: UUID | str, name: str | None = None) -> SubjectCreateDTO:
        return SubjectCreateDTO(
            creatorUserId=user_id,
            name=name if name is not None else Func.random_subject()
        )

    @staticmethod
    def exam(user_id: UUID | str, subject_id: UUID | str) -> ExamCreateDTO:
        type: ExamType = [ExamType.SESSIONAL, ExamType.MID, ExamType.FINAL][rd.randint(0, 2)]
        marks: int = 100 if type is ExamType.FINAL else 50 if type is ExamType.MID else 25

        return ExamCreateDTO(
            creatorUserId=user_id,
            subjectId=subject_id,
            type=type,
            totalMarks=marks,
            conductedDate=fk.date()
        )

    @staticmethod
    def exam_log(user_id: UUID | str, student_id: UUID | str, exam_id: UUID | str, total_marks: int, note: str | None = None) -> StudentExamLogsCreateDTO:
        obtainedMarks: int = rd.randint(0, total_marks)
        percentage: int = int((obtainedMarks / total_marks) * 100)
        status: ExamStatus = ExamStatus.FAIL if percentage < 50 else ExamStatus.PASS

        return StudentExamLogsCreateDTO(
            studentId=student_id,
            examId=exam_id,
            creatorUserId=user_id,
            obtainedMarks=obtainedMarks,
            status=status,
            note=note
        )

class Func:
    @staticmethod
    def random_subject() -> str:
        prefix: str = rd.choice(subject['prefix'])
        core: str = rd.choice(subject['core'])

        suffix = rd.choice(["II", "Techniques", "Applications"]) if prefix in ["Advanced", "Applied"] else rd.choice(subject['suffix'])

        return f'{prefix} {core} {suffix}'

    @staticmethod
    def unique_subjects_limit() -> int:
        # Current: 26,928
        return len(subject['prefix']) * len(subject['core']) * len(subject['suffix'])
