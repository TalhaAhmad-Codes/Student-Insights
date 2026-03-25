from api.client import ApiClient
from api.routes import StudentExamLogs

api = ApiClient()


class StudentExamLogsService:
    @staticmethod
    def get_all():
        return api.get(StudentExamLogs.Get.all())

    @staticmethod
    def get_all_detailed():
        return api.get(StudentExamLogs.Get.all_detailed())

    @staticmethod
    def create_bulk(data: list):
        return api.post(StudentExamLogs.Post.create_bulk(), data)
