Vagrant.configure("2") do |config|

    
    # config.vm.define "windows" do |windows|
    #   windows.vm.box = "gusztavvargadr/windows-10"
    #   windows.vm.hostname = "windows-vm"
    #   windows.vm.network "public_network"
    #   windows.vm.provider "virtualbox" do |vb|
    #     vb.memory = "4096"
    #     vb.cpus = 4
    #   end
    #   windows.vm.provision "shell", run: "always", inline: <<-SHELL
    #     # Set execution policy to bypass script restriction
    #     Set-ExecutionPolicy Bypass -Scope Process -Force

    #     # Install Chocolatey
    #     Write-Host "------------------- Installing Chocolatey... -------------------"
    #     try {
    #         [System.Net.WebClient]::new().DownloadString('https://chocolatey.org/install.ps1') | Invoke-Expression
    #     } catch {
    #         Write-Host "----------------- Failed to install Chocolatey. Exiting... -----------------"
    #         exit 1
    #     }

    #     # Install .NET 8.0 SDK and Runtime
    #     Write-Host "----------------- Installing .NET 8.0 SDK and Runtime... -----------------"
    #     choco install dotnet-8.0-sdk -y
    #     choco install dotnet-8.0-runtime -y
    #     if (dotnet --version) {
    #         Write-Host "----------------- .NET Core 8 successfully installed. -----------------"
    #     } else {
    #         Write-Host "------------------- Failed to install .NET Core 8. Exiting... ------------------"
    #         exit 1
    #     }

    #     # Verify .NET SDK and Runtime installation
    #     dotnet --list-sdks
    #     dotnet --list-runtimes

    #     # Install .NET Core 3.1 SDK
    #     Write-Host "------------------- Installing .NET 3.1 SDK -------------------"
    #     choco install dotnetcore-sdk -y
    #     if (dotnet --list-sdks | Select-String "3.1") {
    #         Write-Host "---------------- .NET Core 3.1 SDK successfully installed. ----------------"
    #     } else {
    #         Write-Host "---------------- Failed to install .NET Core 3.1 SDK. Exiting... ----------------"
    #         exit 1
    #     }

    #     # Download and extract BaGet
    #     Write-Host "------------------- Downloading and setting up BaGet... -------------------"
    #     if (Test-Path "C:/Users/vagrant/baget") {
    #         Write-Host "---------------------- BaGet is already installed ----------------------"
    #     } else {
    #         Invoke-WebRequest -Uri "https://github.com/loic-sharma/BaGet/releases/download/v0.4.0-preview2/BaGet.zip" -OutFile "C:/tmp/BaGet.zip"
    #         Expand-Archive -Path "C:/tmp/BaGet.zip" -DestinationPath "C:/Users/vagrant/baget" -Force
    #         Remove-Item "C:/tmp/BaGet.zip"

    #         if (Test-Path "C:/Users/vagrant/baget") {
    #             Write-Host "------------------------ BaGet setup complete. ------------------------"
    #         } else {
    #             Write-Host "---------------- Failed to set up BaGet. Exiting... ----------------"
    #             exit 1
    #         }
    #     }

        
      
    #     # Check if BaGet is running
    #     $response = Invoke-WebRequest -Uri "http://localhost:5000" -UseBasicParsing
    #     if ($response.StatusCode -eq 200) {
    #         Write-Host "------------------------- BaGet is already started --------------------------"
    #     } else {
          
    #       # Run BaGet
    #       Write-Host "------------------------- Running BaGet -------------------------"
    #       cd "C:/Users/vagrant/baget"
    #       start dotnet BaGet.dll

    #       try {
    #         $response2 = Invoke-WebRequest -Uri "http://localhost:5000" -UseBasicParsing
    #         if ($response2.StatusCode -eq 200) {
    #             Write-Host "---------------------- BaGet Started successfully ----------------------"
    #         } else {
    #             Write-Host "--------------------- Failed to start BaGet. Exiting... ---------------------"
    #             exit 1
    #         }
    #       } catch {
    #           Write-Host "----------- Failed to connect to BaGet on http://localhost:5000. Exiting... -----------"
    #           exit 1
    #       }
    #     }

    #     # Add BaGet source and build Lab4
    #     cd /vagrant/Lab4
    #     Write-Host "--------------- Configuring BaGet as a NuGet source... ---------------"
    #     dotnet nuget add source http://localhost:5000/v3/index.json -n BaGet
    #     if (dotnet nuget list source | Select-String "BaGet") {
    #         Write-Host "-------------------- BaGet source added successfully --------------------"
    #     } else {
    #         Write-Host "---------------- Failed to add BaGet as a NuGet source. Exiting... ----------------"
    #         exit 1
    #     }

    #     Write-Host "--------------------- Building Lab4 project... ---------------------"
    #     dotnet build
    #     if (Test-Path "./bin/Release/Lab4.1.0.1.nupkg") {
    #         Write-Host "--------------------- Lab4 project built successfully ---------------------"
    #     } else {
    #         Write-Host "------------------- Failed to build Lab4 project. Exiting... -------------------"
    #         exit 1
    #     }

    #     # Check if package exists in BaGet
    #     Write-Host "--------------------- Checking if package already exists in BaGet... ---------------------"
    #     $packageExists = $false
    #     try {
    #         $response = Invoke-WebRequest -Uri "http://localhost:5000/v3/registration/VHriss/1.0.1.json" -UseBasicParsing
    #         if ($response.StatusCode -eq 200) {
    #             $packageExists = $true
    #             Write-Host "--------------------- Package already exists in BaGet. Skipping push... ---------------------"
    #         }
    #     } catch {

    #     }

    #     # Push the package to BaGet if it doesn't exist
    #     if (-not $packageExists) {
    #             Write-Host "-------------------- Package does not exist. Pushing package to BaGet... --------------------"
    #         dotnet nuget push -s http://localhost:5000/v3/index.json ./bin/Release/Lab4.1.0.1.nupkg --skip-duplicate
    #         if ($?) {
    #             Write-Host "------------------- Package pushed to BaGet successfully -------------------"
    #         } else {
    #             Write-Host "------------------- Failed to push package to BaGet. Exiting... -------------------"
    #             exit 1
    #         }
    #     }

    #     # Install the tool
    #     Write-Host "---------------- Installing tool Lab4 globally... ----------------"
    #     dotnet tool install --global Lab4 --version 1.0.1
    #     if (dotnet tool list -g | Select-String "Lab4") {
    #         Write-Host "------------------ Tool VHriss installed successfully ------------------"
    #     } else {
    #         Write-Host "------------------- Failed to install tool VHriss. Exiting... -------------------"
    #         exit 1
    #     }

    #     Write-Host "--------------------- Run 'Lab4' to launch the tool. ---------------------"
    #   SHELL
    # end

    config.vm.define "linux" do |linux|
    linux.vm.box = "hashicorp/bionic64"
    linux.vm.hostname = "linux-vm"
    linux.vm.network "public_network"

    linux.vm.provider "virtualbox" do |vb|
      vb.memory = "4096"
      vb.cpus = 4
    end
    
    linux.vm.provision "shell", run: "always", inline: <<-SHELL
        # Update and install prerequisites
        sudo apt-get update
        sudo apt-get install -y wget apt-transport-https unzip

        # Install .NET SDK 8.0
        wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
        sudo dpkg -i packages-microsoft-prod.deb
        sudo apt-get update
        sudo apt-get install -y dotnet-sdk-8.0

        # Install .NET Core 3.1 SDK
        sudo apt-get install -y dotnet-sdk-3.1

        # Verify .NET SDK and Runtime installations
        dotnet --list-sdks
        dotnet --list-runtimes

        # Download and extract BaGet
        echo "------------------- Setting up BaGet... -------------------"
        if [ -d "/home/vagrant/baget" ]; then
            echo "------------------- BaGet is already installed -------------------"
        else
            wget https://github.com/loic-sharma/BaGet/releases/download/v0.4.0-preview2/BaGet.zip -O BaGet.zip
            unzip BaGet.zip -d /home/vagrant/baget
            rm BaGet.zip
            if [ -d "/home/vagrant/baget" ]; then
                echo "------------------- BaGet setup complete -------------------"
            else
                echo "------------------- Failed to set up BaGet. Exiting... -------------------"
                exit 1
            fi
        fi

        # Check if BaGet is running
        RESPONSE=$(curl -o /dev/null -s -w "%{http_code}" http://localhost:5000)
        if [ "$RESPONSE" -eq 200 ]; then
            echo "------------------- BaGet is already running -------------------"
        else
            # Start BaGet
            echo "------------------- Starting BaGet -------------------"
            cd /home/vagrant/baget
            nohup dotnet BaGet.dll > /dev/null 2>&1 &
            sleep 5
            RESPONSE=$(curl -o /dev/null -s -w "%{http_code}" http://localhost:5000)
            if [ "$RESPONSE" -eq 200 ]; then
                echo "------------------- BaGet started successfully -------------------"
            else
                echo "------------------- Failed to start BaGet. Exiting... -------------------"
                exit 1
            fi
        fi

        # Add BaGet source and build Lab4
        cd /vagrant/Lab4
        echo "--------------- Configuring BaGet as a NuGet source... ---------------"
        dotnet nuget add source http://localhost:5000/v3/index.json -n BaGet
        if dotnet nuget list source | grep -q "BaGet"; then
            echo "------------------- BaGet source added successfully -------------------"
        else
            echo "------------------- Failed to add BaGet as a NuGet source. Exiting... -------------------"
            exit 1
        fi

        echo "------------------- Building Lab4 project... -------------------"
        dotnet build
        if [ -f "./bin/Release/Lab4.1.0.1.nupkg" ]; then
            echo "------------------- Lab4 project built successfully -------------------"
        else
            echo "------------------- Failed to build Lab4 project. Exiting... -------------------"
            exit 1
        fi

        # Check if package exists in BaGet
        echo "------------------- Checking if package exists in BaGet... -------------------"
        PACKAGE_EXISTS=$(curl -s -o /dev/null -w "%{http_code}" http://localhost:5000/v3/registration/VHriss/1.0.0.json)
        if [ "$PACKAGE_EXISTS" -eq 200 ]; then
            echo "------------------- Package already exists in BaGet. Skipping push... -------------------"
        else
            echo "------------------- Package does not exist. Pushing package to BaGet... -------------------"
            dotnet nuget push -s http://localhost:5000/v3/index.json ./bin/Release/Lab4.1.0.1.nupkg --skip-duplicate
            if [ $? -eq 0 ]; then
                echo "------------------- Package pushed to BaGet successfully -------------------"
            else
                echo "------------------- Failed to push package to BaGet. Exiting... -------------------"
                exit 1
            fi
        fi

        # Install the tool
        echo "------------------- Installing tool Lab4 globally... -------------------"
        dotnet tool install --global Lab4 --version 1.0.1 --add-source http://localhost:5000/v3/index.json


        dotnet tool install --global Lab4 --version 1.0.1 --add-source http://localhost:5000/v3/index.json

        echo "------------------- Run 'Lab4' to launch the tool. -------------------"
    SHELL
  end
    
end