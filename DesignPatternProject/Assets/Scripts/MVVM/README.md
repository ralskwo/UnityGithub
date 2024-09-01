# Unity Design Pattern Project - MVVM Example

## 프로젝트 개요

이 프로젝트는 유니티(Unity)를 사용하여 MVVM(Model-View-ViewModel) 디자인 패턴을 구현한 예제입니다. MVVM 패턴은 모델과 뷰를 뷰모델(ViewModel)로 분리하여 데이터 바인딩과 UI 업데이트를 자동화하고, 코드의 테스트 용이성과 유지보수성을 높이는 데 중점을 둡니다.

## 프로젝트 구조

### Model

- **UserDataModel.cs**: 사용자의 이름과 나이를 관리하는 클래스입니다. 사용자 데이터를 담고 있으며, ViewModel을 통해 UI와 연결됩니다.

### ViewModel

- **UserViewModel.cs**: 모델과 뷰 사이의 중개 역할을 담당하며, 데이터 바인딩과 UI 업데이트를 처리합니다. `INotifyPropertyChanged` 인터페이스를 구현하여, 데이터 변경 시 뷰에 자동으로 반영되도록 합니다.

### View

- **UserView.cs**: 유니티 UI 요소를 사용하여 사용자의 입력을 처리하고, ViewModel과 상호작용하여 화면에 데이터를 표시합니다. 데이터 입력 필드와 표시 텍스트가 포함되어 있으며, 사용자 입력 변화에 따라 ViewModel을 업데이트합니다.

## 사용 방법

1. 프로젝트를 클론하고 Unity에서 열어주세요.
2. 이름과 나이를 입력하여 MVVM 패턴에 따라 데이터가 실시간으로 업데이트되고 반영되는 것을 확인할 수 있습니다.
3. MVVM 패턴이 어떻게 적용되었는지 코드와 구조를 통해 학습할 수 있습니다.

## 참조

- [MVVM 패턴 이해 및 활용](https://mayquartet.com/unity-mvvmmodel-view-viewmodel-%ed%8c%a8%ed%84%b4-%ec%9d%b4%ed%95%b4-%eb%b0%8f-%ed%99%9c%ec%9a%a9/): 이 프로젝트에서 구현된 MVVM 패턴에 대한 추가적인 설명은 이 블로그 글을 참조하세요.
