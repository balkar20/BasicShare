FROM jenkins/jenkins:latest
MAINTAINER Swire Chen<idoop@msn.cn>

#----Install .Net Core SDK & Nuget & Python3----#
USER root
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
    python3-dev \
    python3-pip \
	    libc6 \
        libgcc1 \
        libgssapi-krb5-2 \
        libicu57 \
        liblttng-ust0 \
        libssl1.0.2 \
        libstdc++6 \
        zlib1g \
    apt-transport-https \
    && rm -rf /var/lib/apt/lists/* \
    && git config --global credential.helper store \
    && rm /usr/bin/python && ln -s /usr/bin/python3.5 /usr/bin/python \
    && ln -s /usr/bin/pip3 /usr/bin/pip \
    && pip install setuptools wheel \
    && pip install paramiko==2.4.1 \
                python-gitlab==1.7.0 \
                python-jenkins==1.0.1 \
                urllib3==1.22 \
                requests==2.18.4 \
                kubernetes==6.0.0 \
                pytz==2018.4 \
                PyYAML==3.12 \
                msgpack==0.5.6 \
                pytest==3.9.2 \
                fabric==2.4.0 \
    && curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - \
    && echo "deb [arch=amd64] https://packages.microsoft.com/repos/microsoft-debian-stretch-prod stretch main" > /etc/apt/sources.list.d/microsoft.list \
    && apt-get update \
    && apt-get install -y --no-install-recommends powershell \
    && rm -rf /var/lib/apt/lists/* \
    && git config --global credential.helper store \
    # Set Timezone with CST
    && /bin/cp /usr/share/zoneinfo/Asia/Shanghai /etc/localtime \
    && echo 'Asia/Shanghai' >/etc/timezone
 
# Install .NET Core SDK
ENV DOTNET_SDK_VERSION 2.2.100

RUN curl -SL --output dotnet.tar.gz https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$DOTNET_SDK_VERSION/dotnet-sdk-$DOTNET_SDK_VERSION-linux-x64.tar.gz \
    && dotnet_sha512='6bde1d0f186f068b1300d5a67e8aba56ff271b940bc0782c3a254dc0f67e7167d2fca12fc51eb3319d4ab4a91cbe5639e5104e9e0036adb8a27ca5711453a1c3' \
    && echo "$dotnet_sha512 dotnet.tar.gz" | sha512sum -c - \
    && mkdir -p /usr/share/dotnet \
    && tar -zxf dotnet.tar.gz -C /usr/share/dotnet \
    && rm dotnet.tar.gz \
    && ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet

# Trigger the population of the local package cache
ENV DOTNET_RUNNING_IN_CONTAINER=true \
    DOTNET_USE_POLLING_FILE_WATCHER=true
#    NUGET_XMLDOC_MODE=skip
# 	 ASPNETCORE_URLS=http://+:80 



  
USER jenkins
FROM jenkins/jenkins:2.401.1
USER root
RUN apt-get update && apt-get install -y lsb-release
RUN curl -fsSLo /usr/share/keyrings/docker-archive-keyring.asc \
  https://download.docker.com/linux/debian/gpg
RUN echo "deb [arch=$(dpkg --print-architecture) \
  signed-by=/usr/share/keyrings/docker-archive-keyring.asc] \
  https://download.docker.com/linux/debian \
  $(lsb_release -cs) stable" > /etc/apt/sources.list.d/docker.list
RUN apt-get update && apt-get install -y docker-ce-cli
USER jenkins
RUN jenkins-plugin-cli --plugins "blueocean docker-workflow"