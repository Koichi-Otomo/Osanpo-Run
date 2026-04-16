
project 'Built Program iOS/Unity-iPhone.xcodeproj'
platform :ios, '12.0'

target 'Unity-iPhone' do
  pod 'IronSourceSDK', '8.10.0.0'
end

target 'UnityFramework' do
  pod 'IronSourceSDK', '8.10.0.0'
end

post_install do |installer|
  installer.pods_project.targets.each do |target|
    target.build_configurations.each do |config|
      config.build_settings['IPHONEOS_DEPLOYMENT_TARGET'] = '12.0'
    end
  end
end