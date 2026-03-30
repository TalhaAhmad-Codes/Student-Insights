class Unique:
    def __init__(self, count: int):
        self.__count: int = count
        self.__data: list = []

    @property
    def size(self) -> int:
        return len(set(self.__data))

    @property
    def data(self) -> list:
        return list(set(self.__data))

    def add(self, value) -> None:
        self.__data.append(value)

    def generate(self, data: list) -> None:
        self.__data = data

    @staticmethod
    def contains_duplicate(data: list) -> bool:
        return len(data) != len(set(data))
