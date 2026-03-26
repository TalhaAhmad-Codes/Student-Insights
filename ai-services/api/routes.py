from uuid import UUID

##################################################
# ENVIRONMENT VARIABLES
##################################################

# Global values
GLOBAL = {
    'host': 'http://localhost:5011'
}

# The API endpoint
BASE_URL: str = f"{GLOBAL['host']}/api/"

##################################################
# API Endpoints
##################################################

# ********** User - Endpoints ********** #
class User:
    ENDPOINT: str = f"User"

    # GET
    class Get:
        @staticmethod
        def all() -> str:
            return f"{User.ENDPOINT}"

        @staticmethod
        def by_id(_id: UUID | str) -> str:
            return f"{User.ENDPOINT}/{_id}"

    # POST
    class Post:
        @staticmethod
        def create() -> str:
            return f"{User.ENDPOINT}"

        @staticmethod
        def create_bulk() -> str:
            return f"{User.ENDPOINT}/bulk"

    # PATCH
    class Patch:
        @staticmethod
        def update_profile_pic() -> str:
            return f"{User.ENDPOINT}/update/profile-pic"

        @staticmethod
        def update_username() -> str:
            return f"{User.ENDPOINT}/update/username"

        @staticmethod
        def update_password() -> str:
            return f"{User.ENDPOINT}/update/password"

    # DELETE
    class Delete:
        @staticmethod
        def by_id(_id: UUID) -> str:
            return f"{User.ENDPOINT}/{_id}"

# ********** Department - Endpoints ********** #
class Department:
    ENDPOINT: str = f"Department"

    # GET
    class Get:
        @staticmethod
        def all() -> str:
            return f"{Department.ENDPOINT}"

        @staticmethod
        def by_id(_id: UUID | str) -> str:
            return f"{Department.ENDPOINT}/{_id}"

    # POST
    class Post:
        @staticmethod
        def create() -> str:
            return f"{Department.ENDPOINT}"

        @staticmethod
        def create_bulk() -> str:
            return f"{Department.ENDPOINT}/bulk"

    # PUT
    class Put:
        @staticmethod
        def update() -> str:
            return f"{Department.ENDPOINT}"

    # DELETE
    class Delete:
        @staticmethod
        def by_id(_id: UUID) -> str:
            return f"{Department.ENDPOINT}/{_id}"

# ********** Student - Endpoints ********** #
class Student:
    ENDPOINT: str = f"Student"

    # GET
    class Get:
        @staticmethod
        def all() -> str:
            return f"{Student.ENDPOINT}"

        @staticmethod
        def by_id(_id: UUID | str) -> str:
            return f"{Student.ENDPOINT}/{_id}"

    # POST
    class Post:
        @staticmethod
        def create() -> str:
            return f"{Student.ENDPOINT}"

        @staticmethod
        def create_bulk() -> str:
            return f"{Student.ENDPOINT}/bulk"

    # PUT
    class Put:
        @staticmethod
        def update() -> str:
            return f"{Student.ENDPOINT}"

    # DELETE
    class Delete:
        @staticmethod
        def by_id(_id: UUID) -> str:
            return f"{Student.ENDPOINT}/{_id}"

# ********** Exam - Endpoints ********** #
class Exam:
    ENDPOINT: str = f"Exam"

    # GET
    class Get:
        @staticmethod
        def all() -> str:
            return f"{Exam.ENDPOINT}"

        @staticmethod
        def by_id(_id: UUID | str) -> str:
            return f"{Exam.ENDPOINT}/{_id}"

    # POST
    class Post:
        @staticmethod
        def create() -> str:
            return f"{Exam.ENDPOINT}"

        @staticmethod
        def create_bulk() -> str:
            return f"{Exam.ENDPOINT}/bulk"

    # PUT
    class Put:
        @staticmethod
        def update() -> str:
            return f"{Exam.ENDPOINT}"

    # DELETE
    class Delete:
        @staticmethod
        def by_id(_id: UUID) -> str:
            return f"{Exam.ENDPOINT}/{_id}"

# ********** Student Exam Logs - Endpoints ********** #
class StudentExamLogs:
    ENDPOINT: str = f"StudentExamLogs"

    # GET
    class Get:
        @staticmethod
        def all() -> str:
            return f"{StudentExamLogs.ENDPOINT}"

        @staticmethod
        def by_id(_id: UUID | str) -> str:
            return f"{StudentExamLogs.ENDPOINT}/{_id}"

        @staticmethod
        def all_detailed() -> str:
            return  f"{StudentExamLogs.ENDPOINT}/detailed"

        @staticmethod
        def by_id_detailed(_id: UUID) -> str:
            return f"{StudentExamLogs.ENDPOINT}/detailed/{_id}"

    # POST
    class Post:
        @staticmethod
        def create() -> str:
            return f"{StudentExamLogs.ENDPOINT}"

        @staticmethod
        def create_bulk() -> str:
            return f"{StudentExamLogs.ENDPOINT}/bulk"

    # PUT
    class Put:
        @staticmethod
        def update() -> str:
            return f"{StudentExamLogs.ENDPOINT}"

    # DELETE
    class Delete:
        @staticmethod
        def by_id(_id: UUID) -> str:
            return f"{StudentExamLogs.ENDPOINT}/{_id}"
